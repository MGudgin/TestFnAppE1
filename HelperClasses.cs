namespace PlayFab.CloudScript
{
    using PlayFab.ProfilesModels;

    public class TitleAuthenticationContext
    {
        public string Id { get; set; }
        public string SecretKey { get; set; }
        public string EntityToken { get; set; }
    }

    public class FunctionExecutionContext<T>
    {
        public T FunctionParameter { get; set; }

        public EntityProfileBody CallerEntityProfile { get; set; }
        
        public TitleAuthenticationContext TitleAuthenticationContext { get; set; }        
    }
}
