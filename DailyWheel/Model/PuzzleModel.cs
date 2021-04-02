using System;

namespace DailyWheel.Model
{
    public class PuzzleModel
    {
        public Guid? Id { get; set; }
        public string? Day { get; set; }
        public DateTime? Date => DateTime.TryParse(Day, out var result) ? result : null;
        public string? Category { get; set; }
        public char?[,] Board { get; set; } = new char?[4, 14];
        public string? UsedLetters { get; set; }

        public static readonly PuzzleModel PrerenderPlaceholder = new();
    }
}
