using Answer;

namespace Tests;

[TestFixture]
public class Tests
{
	[Test]
	[TestCase(1, 1)]
	[TestCase(2, 0)]
	[TestCase(3, 0)]
	[TestCase(4, 2)]
	[TestCase(5, 10)]
	[TestCase(6, 4)]
	[TestCase(7, 40)]
	[TestCase(8, 92)]
	[TestCase(9, 352)]
	[TestCase(10, 724)]
	public void Should_Success(int n, int expectedCount)
	{
		var solution = new Solution();

		var result = solution.Solve(n);

		Assert.AreEqual(expectedCount, result.Count);
	}
}