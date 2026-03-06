using System;

namespace DecalCore.Extensions;

public static class TimeSpanExtensions {
    extension(TimeSpan timeSpan) {
        public string FormatToString() {
            return timeSpan.TotalHours >= 1 ? $"{(int)timeSpan.TotalHours}:{timeSpan:mm\\:ss}" : timeSpan.ToString(@"mm\:ss");
        }
    }
}