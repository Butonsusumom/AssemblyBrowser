namespace TestableLibrary.JustNamspace
{
    public class JustClass
    {
        private int foo;
        public string boo;
        protected bool goo;

        public JustClass(int foo, string boo, bool goo)
        {
            this.foo = foo;
            this.boo = boo;
            this.goo = goo;
        }

        public int Foo
        {
            get => foo;
            set => foo = value;
        }
    }
}