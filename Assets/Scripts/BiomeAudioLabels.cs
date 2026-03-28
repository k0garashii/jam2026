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
}
