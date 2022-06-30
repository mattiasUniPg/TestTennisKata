using NUnit.Framework;

/* La partita viene vinta da chi:
 * - Ha almeno 4 punti e almeno due in più dell'altro giocatore
 * - una partita vinta viene chiamata LOVE
 * - 2 partite vinte vengono chiamate Fifteen
 * - 3 partite vinte vengono chiamate Thirty
 * - 4 partite vinte Fourty
 * - SE ogni giocatore possiede 3 vincite la partita è DEUCE*/

namespace TestTennisKata
{
    public class Tests
    {
        private SetResult _setResult;
        private Result _result;
        private ScoreProcessor _scoreProcessor;

        [SetUp]
        public void Setup()
        {
            _setResult = new SetResult();
            _result = new Result();
            _scoreProcessor = new ScoreProcessor();
        }

        [TestCase(1, 0, ResultTypes.LOVE, ResultTypes.NONE)]
        [TestCase(2, 0, ResultTypes.FIFTEEN, ResultTypes.NONE)]
        [TestCase(3, 0, ResultTypes.THIRTY, ResultTypes.NONE)]
        [TestCase(4, 0, ResultTypes.WIN, ResultTypes.LOST)]
        public void Correct_State_For_Player1(int scorePlayer1, int scorePlayer2, ResultTypes resPlayer1, ResultTypes resPlayer2)
        {
            _setResult.ScorePlayer1 = scorePlayer1;
            _setResult.ScorePlayer2 = scorePlayer2;
            _result.resPalyer1 = resPlayer1;
            _result.resPalyer2 = resPlayer2;

            Assert.AreEqual(_result, _setResult);
        }


        [TestCase(0, 1, ResultTypes.NONE, ResultTypes.LOVE)]
        [TestCase(0, 2, ResultTypes.NONE, ResultTypes.FIFTEEN)]
        [TestCase(0, 3, ResultTypes.NONE, ResultTypes.THIRTY)]
        [TestCase(0, 4, ResultTypes.LOST, ResultTypes.WIN)]
        public void Correct_State_For_Player2(int scorePlayer1, int scorePlayer2, ResultTypes resPlayer1, ResultTypes resPlayer2)
        {
            _setResult.ScorePlayer1 = scorePlayer1;
            _setResult.ScorePlayer2 = scorePlayer2;
            _result.resPalyer1 = resPlayer1;
            _result.resPalyer2 = resPlayer2;

            Assert.AreEqual(_result, _setResult); ;
        }

        [TestCase(0, 0, ResultTypes.NONE, ResultTypes.NONE)]
        [TestCase(1, 1, ResultTypes.LOVE, ResultTypes.LOVE)]
        [TestCase(2, 2, ResultTypes.FIFTEEN, ResultTypes.FIFTEEN)]
        [TestCase(3, 3, ResultTypes.THIRTY, ResultTypes.THIRTY)]
        public void Same_Result_For_All_Player(int scorePlayer1, int scorePlayer2, ResultTypes resPlayer1, ResultTypes resPlayer2)
        {
            _setResult.ScorePlayer1 = scorePlayer1;
            _setResult.ScorePlayer2 = scorePlayer2;
            _result.resPalyer1 = resPlayer1;
            _result.resPalyer2 = resPlayer2;

            Assert.AreEqual(_result, _setResult); ;
        }

        [TestCase(1, 2, ResultTypes.LOVE, ResultTypes.FIFTEEN)]
        [TestCase(2, 1, ResultTypes.FIFTEEN, ResultTypes.LOVE)]
        [TestCase(1, 3, ResultTypes.LOVE, ResultTypes.THIRTY)]
        [TestCase(3, 1, ResultTypes.THIRTY, ResultTypes.LOVE)]
        [TestCase(2, 3, ResultTypes.FIFTEEN, ResultTypes.THIRTY)]
        [TestCase(3, 2, ResultTypes.THIRTY, ResultTypes.FIFTEEN)]
        public void Different_Result_Before_Win(int scorePlayer1, int scorePlayer2, ResultTypes resPlayer1, ResultTypes resPlayer2)
        {
            _setResult.ScorePlayer1 = scorePlayer1;
            _setResult.ScorePlayer2 = scorePlayer2;
            _result.resPalyer1 = resPlayer1;
            _result.resPalyer2 = resPlayer2;

            Assert.AreEqual(_result, _setResult); ;
        }

        [TestCase(4, 1, ResultTypes.WIN, ResultTypes.LOST)]
        [TestCase(1, 4, ResultTypes.WIN, ResultTypes.LOST)]
        [TestCase(4, 2, ResultTypes.WIN, ResultTypes.LOST)]
        [TestCase(2, 4, ResultTypes.WIN, ResultTypes.LOST)]
        [TestCase(5, 3, ResultTypes.WIN, ResultTypes.LOST)]
        [TestCase(3, 5, ResultTypes.WIN, ResultTypes.LOST)]
        public void Winner_Looser_Match(int scorePlayer1, int scorePlayer2, ResultTypes resPlayer1, ResultTypes resPlayer2)
        {
            _setResult.ScorePlayer1 = scorePlayer1;
            _setResult.ScorePlayer2 = scorePlayer2;
            _result.resPalyer1 = resPlayer1;
            _result.resPalyer2 = resPlayer2;

            Assert.AreEqual(_result, _setResult); ;
        }

        [TestCase(4, 4, ResultTypes.DEUCE, ResultTypes.DEUCE)]
        public void Same_Result_For_All_Player_After_Third_Set(int scorePlayer1, int scorePlayer2, ResultTypes resPlayer1, ResultTypes resPlayer2)
        {
            _setResult.ScorePlayer1 = scorePlayer1;
            _setResult.ScorePlayer2 = scorePlayer2;
            _result.resPalyer1 = resPlayer1;
            _result.resPalyer2 = resPlayer2;

            Assert.AreEqual(_result, _setResult); ;
        }

        [TestCase(4, 3, ResultTypes.ADVANTAGE, ResultTypes.ADVANTAGE)]
        [TestCase(3, 4, ResultTypes.ADVANTAGE, ResultTypes.ADVANTAGE)]
        [TestCase(5, 4, ResultTypes.ADVANTAGE, ResultTypes.ADVANTAGE)]
        [TestCase(4, 5, ResultTypes.ADVANTAGE, ResultTypes.ADVANTAGE)]
        [TestCase(9, 8, ResultTypes.ADVANTAGE, ResultTypes.ADVANTAGE)]
        [TestCase(8, 9, ResultTypes.ADVANTAGE, ResultTypes.ADVANTAGE)]
        public void Advantage_Results_Test(int scorePlayer1, int scorePlayer2, ResultTypes resPlayer1, ResultTypes resPlayer2)
        {
            _setResult.ScorePlayer1 = scorePlayer1;
            _setResult.ScorePlayer2 = scorePlayer2;
            _result.resPalyer1 = resPlayer1;
            _result.resPalyer2 = resPlayer2;

            Assert.AreEqual(_result, _setResult); ;
        }

        [Test]
        public void Score_processor_test()
        {
            Assert.Throws<NegativeScoreNotSupportedException>(() => _scoreProcessor.Process(new SetResult { ScorePlayer1 = -1, ScorePlayer2 = -1 }));
        }
    }
}