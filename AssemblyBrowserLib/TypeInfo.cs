namespace AssemblyBrowserLib
{
    public class TypeInfo : ContainerInfo
    {
        public TypeInfo() : base()
        {
        }
        public override MemberType GetContainerType => MemberType.Type;
    }
}
