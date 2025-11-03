//using Xunit;
//using Moq;
//using System.Threading.Tasks;
//using System.Linq.Expressions;
//using Toppine.IRepository;
//using Toppine.Model.Entities;
//using Toppine.Model.ViewModels.DTO;
//using Toppine.Services;

//namespace Toppine.Services.Tests
//{
//    public class RRFServiceTests
//    {
//        // 模拟数据访问层接口
//        private readonly Mock<IRRFRepository> _mockDal;
//        // 待测试的服务实例
//        private readonly RRFService _service;

//        public RRFServiceTests()
//        {
//            // 初始化Moq实例
//            _mockDal = new Mock<IRRFRepository>();
//            // 实例化服务（注入模拟的依赖）
//            _service = new RRFService(_mockDal.Object);
//        }

//        #region 常规错误检查测试
//        /// <summary>
//        /// 测试：当CRNRRF为空时，返回错误信息
//        /// </summary>
//        [Fact]
//        public async Task CheckData_WhenCRNRRFIsEmpty_ReturnsError()
//        {
//            // Arrange：准备测试数据
//            var para = new RRFDto { ID = 0, CRNRRF = "" }; // CRNRRF为空
//            bool isAdd = true;

//            // Act：调用方法
//            var result = await _service.CheckData(para, isAdd);

//            // Assert：验证结果
//            Assert.False(result.Result); // 结果应为失败
//            Assert.Contains("CRN RRF cannot be null.", result.MessageList); // 包含指定错误信息
//        }
//        #endregion

//        #region 新增场景（isAdd=true）测试
//        /// <summary>
//        /// 测试：新增时CRNRRF已存在，返回错误信息
//        /// </summary>
//        [Fact]
//        public async Task CheckData_WhenAddAndCRNRRFExists_ReturnsError()
//        {
//            // Arrange：准备测试数据
//            var para = new RRFDto { ID = 0, CRNRRF = "EXISTED_RRF" };
//            bool isAdd = true;

//            // 模拟数据库查询：当查询CRNRRF为"EXISTED_RRF"时，返回已存在的实体
//            _mockDal.Setup(dal => dal.QueryByClauseAsync(It.Is<Expression<Func<RRF, bool>>>(expr =>
//                // 验证查询条件是否正确（CRNRRF等于输入值）
//                ((BinaryExpression)expr.Body).Right.ToString() == "\"EXISTED_RRF\""
//            ))).ReturnsAsync(new RRF { ID = 1, CRNRRF = "EXISTED_RRF" });

//            // Act：调用方法
//            var result = await _service.CheckData(para, isAdd);

//            // Assert：验证结果
//            Assert.False(result.Result);
//            Assert.Contains("CRN/RRF is exist!", result.MessageList); // 包含存在提示
//            Assert.NotNull(result.Entity); // 应返回已存在的实体
//        }

//        /// <summary>
//        /// 测试：新增时CRNRRF不存在，返回成功
//        /// </summary>
//        [Fact]
//        public async Task CheckData_WhenAddAndCRNRRFNotExists_ReturnsSuccess()
//        {
//            // Arrange：准备测试数据
//            var para = new RRFDto { ID = 0, CRNRRF = "NEW_RRF" };
//            bool isAdd = true;

//            // 模拟数据库查询：CRNRRF不存在，返回null
//            _mockDal.Setup(dal => dal.QueryByClauseAsync(It.IsAny<Expression<Func<RRF, bool>>>()))
//                .ReturnsAsync((RRF)null);

//            // Act：调用方法
//            var result = await _service.CheckData(para, isAdd);

//            // Assert：验证结果
//            Assert.True(result.Result); // 结果应为成功
//            Assert.Empty(result.MessageList); // 无错误信息
//        }
//        #endregion

//        #region 修改场景（isAdd=false）测试
//        /// <summary>
//        /// 测试：修改时ID不存在，返回错误信息
//        /// </summary>
//        [Fact]
//        public async Task CheckData_WhenUpdateAndIdNotExists_ReturnsError()
//        {
//            // Arrange：准备测试数据
//            var para = new RRFDto { ID = 999, CRNRRF = "ANY_RRF" }; // 不存在的ID
//            bool isAdd = false;

//            // 模拟数据库查询：根据ID查询返回null（ID不存在）
//            _mockDal.Setup(dal => dal.QueryByIdAsync(999))
//                .ReturnsAsync((RRF)null);

//            // Act：调用方法
//            var result = await _service.CheckData(para, isAdd);

//            // Assert：验证结果
//            Assert.False(result.Result);
//            Assert.Contains("FCRN/RRF  is not exist!", result.MessageList); // 包含不存在提示
//        }

//        /// <summary>
//        /// 测试：修改时ID存在且CRNRRF未被占用，返回成功
//        /// </summary>
//        [Fact]
//        public async Task CheckData_WhenUpdateAndIdExistsAndCRNRRFNotUsed_ReturnsSuccess()
//        {
//            // Arrange：准备测试数据
//            var para = new RRFDto { ID = 1, CRNRRF = "UNIQUE_RRF" };
//            bool isAdd = false;

//            // 模拟数据库查询：根据ID查询返回存在的实体
//            _mockDal.Setup(dal => dal.QueryByIdAsync(1))
//                .ReturnsAsync(new RRF { ID = 1, CRNRRF = "OLD_RRF" });

//            // 模拟数据库查询：CRNRRF未被其他实体占用（返回null）
//            _mockDal.Setup(dal => dal.QueryByClauseAsync(It.IsAny<Expression<Func<RRF, bool>>>()))
//                .ReturnsAsync((RRF)null);

//            // Act：调用方法
//            var result = await _service.CheckData(para, isAdd);

//            // Assert：验证结果
//            Assert.True(result.Result);
//            Assert.Empty(result.MessageList);
//        }

//        /// <summary>
//        /// 测试：修改时ID存在但CRNRRF被其他实体占用，返回错误信息
//        /// </summary>
//        [Fact]
//        public async Task CheckData_WhenUpdateAndCRNRRFUsedByOther_ReturnsError()
//        {
//            // Arrange：准备测试数据
//            var para = new RRFDto { ID = 1, CRNRRF = "USED_RRF" };
//            bool isAdd = false;

//            // 模拟数据库查询：根据ID查询返回当前实体（ID=1）
//            _mockDal.Setup(dal => dal.QueryByIdAsync(1))
//                .ReturnsAsync(new RRF { ID = 1, CRNRRF = "OLD_RRF" });

//            // 模拟数据库查询：CRNRRF被其他实体占用（ID=2）
//            _mockDal.Setup(dal => dal.QueryByClauseAsync(It.IsAny<Expression<Func<RRF, bool>>>()))
//                .ReturnsAsync(new RRF { ID = 2, CRNRRF = "USED_RRF" });

//            // Act：调用方法
//            var result = await _service.CheckData(para, isAdd);

//            // Assert：验证结果
//            Assert.False(result.Result);
//            Assert.Contains("CRN/RRF is exist!", result.MessageList);
//        }
//        #endregion
//    }
//}