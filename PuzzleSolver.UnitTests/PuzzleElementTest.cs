namespace PuzzleSolver.UnitTests
{
    using Algorithm;
    using Shouldly;

    public class PuzzleElementTest
    {
        [Fact]
        public void Test1()
        {
            var puzzleElement = new PuzzleElement(0, "TestElement", 0);
            puzzleElement.AddMutation(0, 1);
            puzzleElement.AddMutation(1, 0);
            puzzleElement.Mutations.Count.ShouldBe(2);

            var initialState = new PuzzleState(new List<PuzzleElement> { puzzleElement });
            initialState.ElementStates.ShouldNotBeNull();
            initialState.ElementStates.Length.ShouldBe(1);

            var mutations = initialState.GetPossibleMutations().ToList();
            mutations.Count.ShouldBe(1);

            initialState.ElementStates[0].State.StateValue.ShouldBe(0);

            var firstMutation = mutations[0];
            var mutatedState = initialState.Mutate(firstMutation);
            mutatedState.ElementStates.ShouldNotBeNull();
            mutatedState.ElementStates[0].State.StateValue.ShouldBe(1);

            var mutationsMutated = mutatedState.GetPossibleMutations().ToList();
            mutationsMutated.Count.ShouldBe(1);
        }

        [Fact]
        public void Test2()
        {
            var puzzleElement = new PuzzleElement(0, "TestElement", 0);
            puzzleElement.AddMutation(0, 1);
            puzzleElement.AddMutation(1, 2).AddCondition(puzzleElement, 1).AddAction(puzzleElement, 2);
            puzzleElement.AddMutation(1, 4);
            puzzleElement.AddMutation(1, 5);
            puzzleElement.AddMutation(2, 5);
            puzzleElement.AddMutation(2, 3);

            var elements = new List<PuzzleElement> { puzzleElement };
            var puzzle = new Puzzle();
            var result = puzzle.Process(elements, new List<Tuple<int, int>> { new Tuple<int, int>(0, 3) });
            result.ShouldNotBeNull();
        }
    }
}
