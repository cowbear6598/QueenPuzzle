using Answer.Boards;

namespace Answer;

public class Solution
{
	public IList<IList<string>> Solve(int n)
	{
		var board = new Board(n);

		var result = new List<IList<string>>();

		var currentGridIndex = 0;
		var queenPositions   = new int[n];

		while (currentGridIndex <= board.TotalGridCount)
		{
			var (gridX, gridY) = board.GetGird(currentGridIndex);

			if (!board.CanPutQueen(gridX, gridY))
			{
				Next(ref currentGridIndex, board, gridX, gridY, queenPositions);
				continue;
			}

			queenPositions[gridX] = gridY;
			board.PutQueen(gridX, gridY);

			if (board.IsLast(gridX)) // 確認是否為最後一行，是的話就成功找到一個解
			{
				result.Add(board.ConvertToList());

				board.ClearQueen(gridX, gridY);

				Next(ref currentGridIndex, board, gridX, gridY, queenPositions);
				continue;
			}

			currentGridIndex = (gridX + 1) * n;
		}

		Output(result);

		return result;
	}

	private void Next(ref int currentGridIndex, Board board, int gridX, int gridY, int[] queenPositions)
	{
		// 如果是最後一個格子，則直接回溯，不然就往下一個格子走
		if (!board.IsLast(gridY))
		{
			currentGridIndex++;
			return;
		}

		Backtrace(ref currentGridIndex, board, gridX, queenPositions);
	}

	private void Backtrace(ref int currentGridIndex, Board board, int gridX, int[] queenPositions)
	{
		while (true)
		{
			gridX--;

			if (gridX < 0) // 已經全部回溯完畢
			{
				currentGridIndex = board.TotalGridCount + 1;
				break;
			}

			var queenPosition = queenPositions[gridX];

			board.ClearQueen(gridX, queenPosition);

			// 如果上一個皇后是最後一個格子，則繼續回溯
			if (board.IsLast(queenPosition))
				continue;

			currentGridIndex = gridX * board.GridLength + queenPosition + 1;
			break;
		}
	}

	private void Output(IList<IList<string>> result)
	{
		for (var i = 0; i < result.Count; i++)
		{
			Console.WriteLine($"// Solution {i + 1}");

			foreach (var row in result[i])
			{
				Console.WriteLine(row);
			}

			Console.WriteLine();
		}
	}
}