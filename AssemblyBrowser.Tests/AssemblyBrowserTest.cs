using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyBrowserLib.Tests
{
    [TestClass]
    public class AssemblyBrowserTest
    {
        private readonly IAssemblyBrowser _assemblyBrowser = new AssemblyBrowser();

        private string _testLocation = (Assembly.Load("TestableLibrary")).Location;

        [TestMethod]
        public void NamespaceTest()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var namespaces = _assemblyBrowser.GetNamespaces(location);
            var _namespace = namespaces[0];
            var currentNamespace = Assembly.GetExecutingAssembly().GetTypes()[0].Namespace;
            Assert.AreEqual(_namespace.DeclarationName, currentNamespace);
        }

        [TestMethod]
        public void TypesTest()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var namespaces = _assemblyBrowser.GetNamespaces(location);
            var _namespace = namespaces[0];
            var types = _namespace.Members;
            Assert.AreEqual(Assembly.GetExecutingAssembly().GetTypes().Length, types.Count);
        }

        [TestMethod]
        public void TypesNameTest()
        {
            var namespaces = _assemblyBrowser.GetNamespaces(_testLocation);
            foreach (var _namespace in namespaces)
            {
                if (_namespace.DeclarationName != "TestableLibrary" && _namespace.DeclarationName != "TestableLibrary.Another")
                {
                    Assert.Fail($"Error in namespace name {_namespace.DeclarationName}");
                }
            }
        }

        [TestMethod]
        public void ExtensionMethodName()
        {
            var namespaces = _assemblyBrowser.GetNamespaces(_testLocation);
            var types = namespaces[0].Members;
            foreach (var type in types)
            {
                if (type.Name == "MyClass")
                {
                    bool flag = false; ;
                    foreach (var member in ((ContainerInfo)type).Members)
                    {
                        if (member.Name == "ExtMethod")
                        {
                            flag = true;
                        }
                    }
                    Assert.IsTrue(flag);
                }
            }
        }

        [TestMethod]
        public void TypeNamesTest()
        {
            var namespaces = _assemblyBrowser.GetNamespaces(_testLocation);
            var types = namespaces[0].Members;
            foreach (var type in types)
            {
                if (type.Name != "MyClass" && type.Name != "MyClassAnother" && type.Name != "ExtClass")
                {
                    Assert.Fail($"Error in type name {type.Name}");
                }

            }
        }
    }
}
