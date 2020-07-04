﻿using Natasha;
using Natasha.Core;
using Natasha.CSharp;
using Natasha.Engine.Utils;
using System;
using Xunit;


namespace NatashaUT
{
    [Trait("快速构建","完整类")]
    public class DynamicClassTest : PrepareTest
    {


        [Fact(DisplayName = "动态类生成测试1")]
        public void RunClassName0()
        {

            //ScriptCompiler.Init();
            string text = @"
namespace HelloWorld
{public class Test{public Test(){
            Name=""111"";
        }public string Name;
        public int Age{get;set;}
    }
}";
            //根据脚本创建动态类
            AssemblyCSharpBuilder oop = new AssemblyCSharpBuilder();
            oop.LogCompilerError();
            oop.LogSyntaxError();
            oop.Compiler.Domain = DomainManagement.Random;
            oop.Add(text);
            Type type = oop.GetTypeFromShortName("Test");
            Assert.Equal("Test", type.Name);
        }




        [Fact(DisplayName = "动态类生成测试2")]
        public void RunClassName4()
        {

            //ScriptCompiler.Init();
            string text = @"
namespace HelloWorld
{public class Test{public Test(){
            Name=""111"";
        }public string Name;
        public int Age{get;set;}
    }
}";
            //根据脚本创建动态类
            var oop = new NAssembly();
            oop.AssemblyBuilder.Compiler.Domain = DomainManagement.Random;
            oop.AddScript(text);
            Type type = oop.GetTypeFromShortName("Test");
            Assert.Equal("Test", type.Name);
        }




        [Fact(DisplayName = "选择类")]
        public void RunClassName1()
        {

            //ScriptCompiler.Init();
            string text = @"using System;
using System.Collections;
using System.Linq;
using System.Text;
 
namespace HelloWorld
{
    public class TestIndex1
    {
        public string Name;
        public int Age{get;set;}
    }
    public class TestIndex2
    {
        public string Name;
        public int Age{get;set;}
    }

    public class TestIndex3
    {
        public string Name;
        public int Age{get;set;}
    }
}

namespace HelloWorld{
    public struct TestStruct1{}
    public struct TestStruct2{}
    public class TestIndex4
    {
        public string Name;
        public int Age{get;set;}
    }
}

";
            //根据脚本创建动态类
            AssemblyCSharpBuilder oop = new AssemblyCSharpBuilder();
            oop.Compiler.Domain = DomainManagement.Random;
            oop.Add(text);
            Type type = oop.GetTypeFromShortName("TestIndex3");
            Assert.Equal("TestIndex3", type.Name);
        }




        [Fact(DisplayName = "选择命名空间+类")]
        public void RunClassName2()
        {
            //ScriptCompiler.Init();
            string text = @"using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Generic;
namespace HelloWorld
{
    public class TestIndex1
    {
        public string Name;
        public int Age{get;set;}
    }
    public class TestIndex2
    {
        public string Name;
        public int Age{get;set;}
        public List<object> ooo;
    }

    public class TestIndex3
    {
        public string Name;
        public int Age{get;set;}
    }
}

namespace HelloWorld{

    public struct TestStruct1{}
    public struct TestStruct2{}
    public class TestIndex4
    {
        public string Name;
        public int Age{get;set;}
    }
}

";
            //根据脚本创建动态类
            Assert.Equal("TestIndex2", ScriptHelper.GetClassName(text, 1, 2));
            Assert.Equal("TestIndex4", ScriptHelper.GetClassName(text, 2, 1));
            Assert.Equal("TestStruct2", ScriptHelper.GetStructName(text, 2, 2));
        }
    }
}
