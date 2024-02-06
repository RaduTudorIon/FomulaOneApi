namespace FormulaOne.Entities.Dtos.Requests;
public class CreateDriverAchievementRequest
{
    public Guid DriverId { get; set; }
    public int WorldChampionships { get; set; }
    public int FasterLap { get; set; }
    public int PolePositions { get; set; }
    public int Wins { get; set; }
}
