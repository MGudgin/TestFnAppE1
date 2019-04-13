// Copyright (C) Microsoft Corporation. All rights reserved.

namespace PlayFab.CloudScript
{
    using PlayFab.ProfilesModels;

    public class LevelComplete
    {
        public int level;
        public int points;
    }

    public class LevelCompleteRequest
    {
        public LevelComplete FunctionParameter { get; set; }

        public EntityKey RequestorEntity { get; set; }

        public EntityProfileBody EntityProfile { get; set; }
    }
}
