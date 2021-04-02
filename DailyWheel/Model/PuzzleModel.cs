using System;
using System.Collections.Generic;

namespace DailyWheel.Model
{
    public class PuzzleModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Day { get; set; }
        public DateTime? Date => DateTime.TryParse(Day, out var result) ? result : null;
        public string Category { get; set; }
        public char?[,] Board { get; set; } = new char?[4, 14];
        public string UsedLetters { get; set; }
    }
}
