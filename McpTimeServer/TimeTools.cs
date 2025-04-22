using System;
using System.ComponentModel;
using ModelContextProtocol.Server;

namespace McpTimeServer.Tools
{
    [McpServerToolType]
    public static class TimeTools
    {
        [McpServerTool, Description("Gets the current time")]
        public static string GetCurrentTime()
        {
            return DateTimeOffset.Now.ToString("dd/MM/yyyy HH:mm:ss"); // Formato de data e hora configurável
        }

        [McpServerTool, Description("Gets time in specific timezone")]
        public static string GetTimeInTimezone(string timezone)
        {
            if (string.IsNullOrEmpty(timezone))
                return "Error: Timezone cannot be null or empty.";

            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById(timezone);
                return TimeZoneInfo.ConvertTime(DateTimeOffset.Now, tz).ToString("dd/MM/yyyy HH:mm:ss"); // Formato configurável
            }
            catch (TimeZoneNotFoundException)
            {
                return $"Error: The timezone '{timezone}' was not found.";
            }
            catch (InvalidTimeZoneException)
            {
                return $"Error: The timezone '{timezone}' is invalid.";
            }
            catch (Exception ex)
            {
                return $"Error: An unexpected error occurred. Details: {ex.Message}";
            }
        }
    }
}
