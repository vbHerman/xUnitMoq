using Xunit;
using Moq;
using Toppine.API.Controllers;
using Toppine.IServices;
using Toppine.IRepository;
using Microsoft.AspNetCore.Mvc;
using Toppine.Model.FromBody;
using Toppine.Model.ViewModels.DTO;

namespace Toppine.XunitTest
{
    public class RRFTests
    {
        ///<summary>
        ///RRF服务测试
        ///</summary>
        public class RRFControllerTests
        {
            private readonly Mock<IRRFService> _mockRRFService;
            private readonly RRFController _rrfController;
            public RRFControllerTests()
            {
                _mockRRFService = new Mock<IRRFService>();
                _rrfController = new RRFController(_mockRRFService.Object);
            }
            [Fact]
            public void GetWelcome_ValidName_ReturnsOkResult()
            {
                // Arrange
                string testName = "张三123";
                string expectedMessage = $"欢迎您，{testName}！这是来自服务层的响应";
                _mockRRFService.Setup(service => service.GetWelcomeMessage(testName)).Returns(expectedMessage);
                // Act
                var result = _rrfController.GetWelcome(testName) as OkObjectResult;
                // Assert
                Assert.NotNull(result);
                Assert.Equal(200, result.StatusCode);
                Assert.Equal(expectedMessage, result.Value);
            }
           
            [Fact]
            public void GetWelcome_EmptyName_ReturnsBadRequest()
            {
                // Arrange
                string testName = "";
                // Act
                var result = _rrfController.GetWelcome(testName) as BadRequestObjectResult;
                // Assert
                Assert.NotNull(result);
                Assert.Equal(400, result.StatusCode);
                Assert.Equal("用户名不能为空", result.Value);
            }



            /// <summary>
            /// 测试InitAsync接口正常调用场景
            /// </summary>
            [Fact]
            public async Task InitAsync_ValidRequest_ReturnsOkResult()
            {
                // 1. Arrage 准备测试数据
                var testPara = new FMInitial() 
                { 
                    LoginName="admin",UID=1,DSPermission= new DistrictSubconPermissonDto() 
                    { 
                        District = new List<int>() { 1 },
                        SubCon = new List<int>() { 1 }
                    } 
                }; // 可根据需要设置测试参数
                var expectedResult = new
                {
                    DistrictList = new object[] { },
                    SubConList = new object[] { },
                    SubConLogDescriptionList = new object[] { },
                    HighRiskWorkList = new object[] { }
                };
                // 2. Act 执行被测试的方法
                // 模拟依赖服务
                var mockRrfService = new Mock<IRRFService>();
                mockRrfService
                    .Setup(service => service.InitAsync(testPara))
                    .ReturnsAsync(expectedResult)
                    .Verifiable(); // 验证该方法是否被调用

                //  创建控制器实例
                var controller = new RRFController(mockRrfService.Object);

                //  调用待测试方法
                var result = await controller.InitAsync(testPara);

                // 3. Assert 验证结果
                Assert.NotNull(result);
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Equal(200, okResult.StatusCode); // 验证状态码
                Assert.Equal(expectedResult, okResult.Value); // 验证返回数据

                //  验证服务方法是否被正确调用
                mockRrfService.Verify(
                    service => service.InitAsync(testPara),
                    Times.Once); // 确保服务方法被调用一次
            }

            /// <summary>
            /// 测试参数为空时的处理（如果有参数验证逻辑可在此扩展）
            /// </summary>
            [Fact]
            public async Task InitAsync_NullParameter_ReturnsExpectedResult()
            {
                // 1. 准备测试数据（参数为null）
                FMInitial testPara = null;

                // 2. 模拟依赖服务
                var mockRrfService = new Mock<IRRFService>();

                // 3. 创建控制器实例
                var controller = new RRFController(mockRrfService.Object);

                // 4. 调用待测试方法
                var result = await controller.InitAsync(testPara);

                // 5. 验证结果（根据实际业务逻辑调整断言）
                Assert.NotNull(result);
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Equal(200, okResult.StatusCode);

                // 6. 验证服务方法调用（如果允许null参数）
                mockRrfService.Verify(
                    service => service.InitAsync(testPara),
                    Times.Once);
            }
        }
    }
}
