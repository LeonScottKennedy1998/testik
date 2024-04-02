using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pract4
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        private int currentQuestionIndex = 0; 
        private List<TestClass> testQuestions;
        private int correctAnswersCount = 0;
        private int totalQuestionsCount;


        public TestPage(List<TestClass> questionsList)
        {
            InitializeComponent();
            testQuestions = questionsList.Where(question => !string.IsNullOrEmpty(question.Title)).ToList();
            totalQuestionsCount = testQuestions.Count;
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            TestClass currentQuestion = testQuestions[currentQuestionIndex];
            TitleLabel.Content = currentQuestion.Title;
            DescriptionLabel.Content = currentQuestion.Description;
            Answer1Button.Content = currentQuestion.Answer1;
            Answer2Button.Content = currentQuestion.Answer2;
            Answer3Button.Content = currentQuestion.Answer3;
            WrongOrRight.Content = ""; 

        }
        
        private void Answer1Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(RightAnwser.Первый);
        }

        private void Answer2Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(RightAnwser.Второй);
        }

        private void Answer3Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(RightAnwser.Третий);
        }


        private void CheckAnswer(RightAnwser selectedAnswer)
        {
            TestClass currentQuestion = testQuestions[currentQuestionIndex];
            if (currentQuestion.RightAnswer == selectedAnswer)
            {
                WrongOrRight.Visibility = Visibility.Visible;
                WrongOrRight.Content = "Верно";
                correctAnswersCount++;

            }
            else
            {
                WrongOrRight.Visibility = Visibility.Visible;

                WrongOrRight.Content = "Неверно";
            }

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); 
            timer.Tick += (sender, e) =>
            {
                timer.Stop(); 
                NextQuestion();
            };
            timer.Start();
        }
        private void NextQuestion()
        {
            currentQuestionIndex++;
            if (currentQuestionIndex < testQuestions.Count)
            {
                ShowQuestion();
            }
            else
            {
                TitleLabel.Visibility = Visibility.Collapsed;
                DescriptionLabel.Visibility = Visibility.Collapsed;
                Answer1Button.Visibility = Visibility.Collapsed;
                Answer2Button.Visibility = Visibility.Collapsed;
                Answer3Button.Visibility = Visibility.Collapsed;

                WrongOrRight.Content = $"Тест завершен! Количество правильных ответов: {correctAnswersCount} из {totalQuestionsCount}";
            }
        }
    }

}

