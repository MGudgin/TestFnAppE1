namespace PlayFab.CloudScript
{
    using PlayFab.ProfilesModels;

    public class EntityRequest<T>
    {
        public T FunctionParameter { get; set; }

        public EntityKey RequestorEntity { get; set; }

        public EntityProfileBody EntityProfile { get; set; }
    }
}
