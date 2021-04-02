using System;

namespace DailyWheel.Model
{
    public class PuzzleModel
    {
        public Guid? Id { get; set; }
        public string? Day { get; set; }
        public string? Category { get; set; }
        public char?[,] Board { get; set; } = new char?[4, 14];
        public string? UsedLetters { get; set; }

        public DateTime? ParseDay() => DateTime.TryParse(Day, out var result) ? result : null;

        public bool IsUnsaved() => !Id.HasValue;

        public bool IsPrerenderInstance() => this == PrerenderPlaceholder;

        public static readonly PuzzleModel PrerenderPlaceholder = new()
        {
            Day = DateTime.Now.ToString("yyyy-MM-dd"),
            Category = "What are you doing?",
            UsedLetters = "RSTLNE ABCD"
        };
    }
}
