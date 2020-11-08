namespace AssemblyBrowserLib
{
    public abstract class Member
    {
        public abstract MemberType GetContainerType { get; }

        public string Name { get; set; }

        public string Modificators { get; set; }

        public string Type { get; set; }

        public string DeclarationName { get; set; }
    }
}
