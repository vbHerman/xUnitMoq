

//单元测试（Unit Test）自的概念
//1、单元测试只专注于测试一个类或者方法。
//2、每个测试用例（TestCase）由Arrange（准备测试数据）、Act（执
//行被测试的方法）、Assert（断言，actual == expected ?）。
//3、单元测试框架由很多，大同小异，这里我们使用xUnit。
//测试项目一般和被测试项目一般放到同一个项目中。
//5、什么类 / 方法不用测试：没有逻辑的类 / 方法。

//xUnit 的基本使用
//1、创建【xUnit测试项目】，并且引用被测试项目。
//2、命名规范：项目名 /namespace/类名+Tests
//3、TestCase名字规范：给定什么条件_期望结果
//4、被测试的类的对应变量名一般叫sut(system under test）
//5、没有参数的TestCase标注[Fact]；有参数的TestCase标注[Theory]，然后
//    使用[InlineData] 等来提供测试数据。
//6、走一个加法的例子。演示通过和不通过。
//7、想一下，对于一个需要注入接口的类，（比如一个用户修改密码的功能需要依赖
//iUserRepository）如何测试；需要测试什么；“怎么做？”
//8.
//AutoFixture+AutoFakeltEasy....
