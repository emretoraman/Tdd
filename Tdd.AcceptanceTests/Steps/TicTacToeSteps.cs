using Tdd.TddInAction;
using TechTalk.SpecFlow;
using Xunit;

namespace Tdd.AcceptanceTests.Steps
{
    [Binding]
    public class TicTacToeSteps
    {
        private TicTacToe _ticTacToe;
        [Given(@"I started a new game")]
        public void GivenIStartedANewGame()
        {
            _ticTacToe = new TicTacToe();
        }
        
        [When(@"I put three crosses in a row")]
        public void WhenIPutThreeCrossesInARow()
        {
            _ticTacToe.MakeMove(1);
            _ticTacToe.MakeMove(4);
            _ticTacToe.MakeMove(2);
            _ticTacToe.MakeMove(5);
            _ticTacToe.MakeMove(3);
        }
        
        [Then(@"I should win")]
        public void ThenIShouldWin()
        {
            Assert.Equal(Winner.Cross, _ticTacToe.GetWinner());
        }
    }
}
