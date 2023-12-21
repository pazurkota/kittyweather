namespace kittyweather.ViewModel;

public static class IconDictionary
{
    public static Dictionary<int, string> GetWeatherIcon() {
        var dictionary = new Dictionary<int, string> {
            {1000, "sunny.svg"},
            {1003, "partly_cloudy.svg"},
            {1006, "cloudy.svg"},
            {1009, "overcast.svg"},
            {1030, "fog.svg"},
            {1063, "showers.svg"},
            {1066, "snow.svg"},
            {1069, "snow.svg"},
            {1072, "snow.svg"},
            {1087, "thunderstorm.svg"},
            {1114, "snow.svg"},
            {1117, "snow.svg"},
            {1135, "fog.svg"},
            {1147, "snow.svg"},
            {1150, "showers.svg"},
            {1153, "showers.svg"},
            {1168, "showers.svg"},
            {1171, "showers.svg"},
            {1180, "showers.svg"},
            {1183, "showers.svg"},
            {1186, "showers.svg"},
            {1189, "showers.svg"},
            {1192, "showers.svg"},
            {1195, "showers.svg"},
            {1198, "showers.svg"},
            {1201, "showers.svg"},
            {1204, "showers.svg"},
            {1207, "showers.svg"},
            {1210, "showers.svg"},
            {1213, "snow.svg"},
            {1216, "snow.svg"},
            {1219, "snow.svg"},
            {1222, "snow.svg"},
            {1225, "snow.svg"},
            {1237, "thunderstorm.svg"},
            {1240, "showers.svg"},
            {1243, "showers.svg"},
            {1246, "showers.svg"},
            {1249, "showers.svg"},
            {1252, "showers.svg"},
            {1255, "showers.svg"},
            {1258, "showers.svg"},
            {1261, "showers.svg"},
            {1264, "showers.svg"},
            {1273, "thunderstorm.svg"},
            {1276, "thunderstorm.svg"},
            {1279, "thunderstorm.svg"},
            {1282, "thunderstorm.svg"}
        };

        return dictionary;
    }
}
