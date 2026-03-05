namespace DecalCore.Extensions;

public static class StringExtensions {
    extension(string input) {
        public bool IsValidString() => !input.IsNullOrEmpty() || !input.IsNullOrWhiteSpace();
        
        // Substring just genuinely sucks...
        public string EnforceLength(int maxLength) => input.Length > maxLength ? input[..maxLength] : input;
    }
}