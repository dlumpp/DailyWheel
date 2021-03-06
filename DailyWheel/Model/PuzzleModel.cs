using System;

namespace DailyWheel.Model
{
    public class PuzzleModel
    {
        public Guid? Id { get; set; }
        public string? Day { get; set; }
        public string? Category { get; set; }
        public BoardSpace[,] Board { get; set; } = BoardSpace.CreateEmptyBoard();
        public string? UsedLetters { get; set; } = AlwaysUsedLetters;

        public DateTime? ParseDay() => DateTime.TryParse(Day, out var result) ? result : null;

        public bool IsUnsaved() => !Id.HasValue;

        public bool IsPrerenderInstance() => this == PrerenderPlaceholder;

        public static readonly PuzzleModel PrerenderPlaceholder = new()
        {
            Day = DateTime.Now.ToString("yyyy-MM-dd"),
            Category = "What are you doing?",
            UsedLetters = AlwaysUsedLetters + " ABCD"
        };

        const string AlwaysUsedLetters = "RSTLNE";
    }
}
