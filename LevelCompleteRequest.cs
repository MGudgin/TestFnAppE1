namespace PlayFab.CloudScript
{
    using Newtonsoft.Json;
    using PlayFab.ProfilesModels;

    public struct LevelComplete
    {
        public int level;
        public int points;
    }

    public class LevelCompleteRequest
    {
        [JsonProperty("FunctionParameter")]
        public LevelComplete level;

        [JsonProperty("RequestorEntity")]
        public EntityKey entityKey;

        [JsonProperty("EntityProfile")]
        public EntityProfileBody profile;
    }
}
