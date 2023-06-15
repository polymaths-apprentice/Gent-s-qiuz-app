const readline = require('readline');

function createInterface() {
  return readline.createInterface({
    input: process.stdin,
    output: process.stdout,
  });
}

function startQuiz() {
  const rl = createInterface();
  let score = 0;
  const totalTime = 60; // Total time in seconds
  let timer;

  // Quiz questions, options, and answers
  const questions = [
    {
      question: 'Who is the biggest Cloud Provider in the Region?',
      options: ['a) AWS', 'b) Azure', 'c) Google', 'd) Linode'],
      answer: 'a',
    },
    {
      question: 'Which framework was created by Facebook?',
      options: ['a) ReactJS', 'b) Vue.JS', 'c) Lavarel', 'd) Django'],
      answer: 'a',
    },
    {
      question: 'Which Progrmming Language is used the most for Web Development?',
      options: ['a) C# and .Net', 'b) JavaScript', 'c) Python', 'd) PHP'],
      answer: 'b',
    },
  ];

  let currentQuestion = 0;

  // Function to display the current question
  function displayQuestion() {
    const question = questions[currentQuestion];
    console.log(question.question);
    question.options.forEach((option) => console.log(option));
    rl.question('Enter your answer (a, b, c, d): ', (answer) => {
      checkAnswer(answer);
    });
  }

  // Function to check the user's answer
  function checkAnswer(answer) {
    const question = questions[currentQuestion];
    if (answer.toLowerCase() === question.answer) {
      console.log('Correct!\n');
      score++;
    } else {
      console.log('Wrong!\n');
    }
    currentQuestion++;
    if (currentQuestion < questions.length) {
      displayQuestion();
    } else {
      endQuiz();
    }
  }

  // Function to end the quiz and display the score
  function endQuiz() {
    clearTimeout(timer);
    console.log('Quiz completed!');
    console.log(`Your score: ${score}/${questions.length}`);
    rl.close();
  }

  // Function to handle time expiration
  function handleTimeExpiration() {
    clearTimeout(timer);
    console.log('Time expired. Quiz ended.');
    console.log(`Your score: ${score}/${questions.length}`);
    rl.close();
  }

  // Function to start the countdown timer
  function startTimer() {
    let remainingTime = totalTime;
    console.log(`You have ${totalTime} seconds to complete the quiz.\n`);

    timer = setInterval(() => {
      remainingTime--;
      console.log(`Time remaining: ${remainingTime} seconds`);

      if (remainingTime <= 0) {
        handleTimeExpiration();
      }
    }, 1000);
  }

  displayQuestion();
  startTimer();
}

// Start the quiz
startQuiz();
