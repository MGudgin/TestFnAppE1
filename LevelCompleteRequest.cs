namespace PlayFab.CloudScript
{
    using Newtonsoft.Json;
    using PlayFab.ProfilesModels;

    public struct LevelComplete
    {
        public int level { get; set; }
        public int points { get; set; }
    }

    public class LevelCompleteRequest
    {
        [JsonProperty("FunctionParameter")]
        public LevelComplete level { get; set; }

        [JsonProperty("RequestorEntity")]
        public EntityKey entityKey { get; set; }

        [JsonProperty("EntityProfile")]
        public EntityProfileBody profile { get; set; }
    }
}
