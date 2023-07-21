namespace GameEngines.ValueObjects
{
    public static class SpinSymbols
    {
        public static SpinSymbol Wildcard = new (nameof(Wildcard), "*", 0);
        public static SpinSymbol Apple = new (nameof(Apple), "A", 0.4);
        public static SpinSymbol Banana = new (nameof(Banana), "B", 0.6);
        public static SpinSymbol Pineapple = new (nameof(Pineapple), "P", 0.8);
    }
}
