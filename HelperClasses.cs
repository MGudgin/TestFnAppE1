namespace PlayFab.CloudScript
{
    using PlayFab.ProfilesModels;

    public class TitleAuthenticationContext
    {
        public string Id { get; set; }
        public string EntityToken { get; set; }
    }

    public class FunctionExecutionContext<T>
    {
        public EntityProfileBody CallerEntityProfile { get; set; }
        
        public TitleAuthenticationContext TitleAuthenticationContext { get; set; }        

        public T FunctionParameter { get; set; }
    }
}
