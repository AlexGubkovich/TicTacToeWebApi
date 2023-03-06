namespace TicTacToeWebApi.Models
{
    public struct Cell
    {
        public int Number { get; set; }

        public CellValues? Value { get; set; }
        public int? PlayerId { get; set; }
    }
}
