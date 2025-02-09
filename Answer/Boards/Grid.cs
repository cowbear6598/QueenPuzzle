namespace Answer.Boards;

public class Grid
{
	private readonly Chess.Chess _chess = new();

	public void PlaceQueen() => _chess.ChangeToQueen();
	public void ClearQueen() => _chess.ClearQueen();

	public bool   CanPlace() => _chess.IsEmpty();
	public string Info()     => _chess.Info();

	public void AddObstacle(int   ownerId) => _chess.ChangeToObstacle(ownerId);
	public void ClearObstacle(int ownerId) => _chess.ClearObstacle(ownerId);
}