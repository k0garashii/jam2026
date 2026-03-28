public static class BiomeAudioLabels
{
    public static string GetBiomeLabel(BiomeType biomeType)
    {
        switch (biomeType)
        {
            case BiomeType.Forest:
                return "Forest";
            case BiomeType.Beach:
                return "Beach";
            case BiomeType.Mountain:
            case BiomeType.BlueShrine:
            case BiomeType.RedShrine:
                return "Mountain";
            case BiomeType.River:
                return "Lake";
            default:
                return "Forest";
        }
    }

    public static string GetAnimalLabel(AnimalType animalType)
    {
        switch (animalType)
        {
            case AnimalType.Owl:
                return "Owl";
            case AnimalType.Wolf:
                return "Wolf";
            case AnimalType.Seagull:
                return "Seagull";
            case AnimalType.Dolphin:
                return "Dolphin";
            case AnimalType.Frog:
                return "Frogs";
            case AnimalType.Duck:
                return "Duck";
            case AnimalType.Bear:
                return "Bear";
            case AnimalType.Eagle:
                return "Eagle";
            case AnimalType.Shrine:
                return "None";
            default:
                return "None";
        }
    }
}
