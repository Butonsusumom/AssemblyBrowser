namespace AssemblyBrowserLib
{
    public interface IAssemblyBrowser
    {
        ContainerInfo[] GetNamespaces(string assemblyPath);
    }
}
