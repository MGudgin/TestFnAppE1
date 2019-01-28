namespace PlayFab.CloudScript
{
    using Newtonsoft.Json;
    using PlayFab.ProfilesModels;

    public class EntityRequest<T>
    {
        [JsonProperty("FunctionParameter")]
        public T parameter { get; set; }

        [JsonProperty("RequestorEntity")]
        public EntityKey entityKey { get; set; }

        [JsonProperty("EntityProfile")]
        public EntityProfileBody entityProfile { get; set; }
    }
}
