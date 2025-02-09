namespace Answer.Chess;

public class Chess
{
	private int       _ownerId;
	private ChessType _type = ChessType.Empty;

	public void ChangeToQueen() => _type = ChessType.Queen;
	public void ChangeToObstacle(int ownerId)
	{
		if (!IsEmpty())
			return;

		_ownerId = ownerId;
		_type    = ChessType.Obstacle;
	}

	public void ClearObstacle(int ownerId)
	{
		if (_ownerId != ownerId)
			return;

		_ownerId = 0;
		_type    = ChessType.Empty;
	}

	public void ClearQueen() => _type = ChessType.Empty;

	public bool IsEmpty() => _type == ChessType.Empty;

	public string Info() => _type switch
	{
		ChessType.Queen => "Q",
		_               => ".",
	};
}