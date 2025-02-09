namespace Answer.Boards;

public class Board
{
	public readonly int GridLength;

	private readonly Grid[,] _grid;

	public Board(int gridLength)
	{
		GridLength = gridLength;

		_grid = new Grid[GridLength, GridLength];

		for (var i = 0; i < GridLength; i++)
		{
			for (var j = 0; j < GridLength; j++)
			{
				_grid[i, j] = new Grid();
			}
		}
	}

	public (int gridX, int gridY) GetGird(int currentGridIndex)
	{
		var gridX = currentGridIndex / GridLength;
		var gridY = currentGridIndex % GridLength;

		return (gridX, gridY);
	}

	public void PutQueen(int gridX, int gridY)
	{
		_grid[gridX, gridY].PlaceQueen();

		UpdateLeftBottomGrid(gridX, gridY, true);
		UpdateBottomGrid(gridX, gridY, true);
		UpdateRightBottomGrid(gridX, gridY, true);
	}

	public void ClearQueen(int gridX, int gridY)
	{
		_grid[gridX, gridY].ClearQueen();

		UpdateLeftBottomGrid(gridX, gridY, false);
		UpdateBottomGrid(gridX, gridY, false);
		UpdateRightBottomGrid(gridX, gridY, false);
	}

	private void UpdateLeftBottomGrid(int gridX, int gridY, bool isObstacle)
	{
		var ownerId = gridX + 1;

		var x = gridX + 1;
		var y = gridY - 1;

		while (!IsOutOfBoard(x, y))
		{
			if (isObstacle)
				_grid[x, y].AddObstacle(ownerId);
			else
				_grid[x, y].ClearObstacle(ownerId);

			x++;
			y--;
		}
	}

	private void UpdateBottomGrid(int gridX, int gridY, bool isObstacle)
	{
		var ownerId = gridX + 1;

		for (var x = gridX + 1; x < GridLength; x++)
		{
			if (isObstacle)
				_grid[x, gridY].AddObstacle(ownerId);
			else
				_grid[x, gridY].ClearObstacle(ownerId);
		}
	}

	private void UpdateRightBottomGrid(int gridX, int gridY, bool isObstacle)
	{
		var ownerId = gridX + 1;

		var x = gridX + 1;
		var y = gridY + 1;

		while (!IsOutOfBoard(x, y))
		{
			if (isObstacle)
				_grid[x, y].AddObstacle(ownerId);
			else
				_grid[x, y].ClearObstacle(ownerId);

			x++;
			y++;
		}
	}

	/// 確認是否可以放置皇后
	public bool CanPutQueen(int gridX, int gridY)
	{
		return _grid[gridX, gridY].CanPlace();
	}

	/// 確認是否超出棋盤
	private bool IsOutOfBoard(int x, int y)
	{
		return x < 0 || x >= GridLength ||
		       y < 0 || y >= GridLength;
	}

	public IList<string> ConvertToList()
	{
		var result = new List<string>();

		for (var i = 0; i < GridLength; i++)
		{
			var row = string.Empty;

			for (var j = 0; j < GridLength; j++)
			{
				row += _grid[i, j].Info();
			}

			result.Add(row);
		}

		return result;
	}

	public int TotalGridCount => _grid.Length;

	public bool IsLast(int gridIndex) => gridIndex == GridLength - 1;
}