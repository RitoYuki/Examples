// /*
// @@@@@@@@@@@@@@@@@@
// @ Method 1       @ 
// @@@@@@@@@@@@@@@@@@
//  Rock Paper Scissors with functions using if statements 
// */
const selectWinnerWithFun = (player1, player2) => {
    let result = null
 
    if(player1 === player2 ){ result ='tie'}
    
    else if (player1==="rock"&&player2==="scissors"){result ="payer1"}
    else if (player1==="paper"&&player2==="rock"){result ="player1"}
    else if (player1==="scissors"&&player2==="paper"){result ="player1"}
 
    else if (player1==="scissors"&&player2==="rock"){result ="player2"}
    else if (player1==="rock"&&player2==="paper"){result ="player2"}
    else if (player1==="paper"&&player2==="scissors"){result ="player2"}
    
    return result
 }
 const playGameFun = (player1,player2)=>{
     return selectWinnerWithFun(player1,player2) 
 }
 console.log(playGameFun("rock","paper")) //player2
 
 // /*
 // @@@@@@@@@@@@@@@@@@
 // @ Method 2       @ 
 // @@@@@@@@@@@@@@@@@@
 //  Rock Paper Scissors with objects using if statements 
 // */
 const selectWinnerWithObj = (player1, player2) => {
     let result = null;
   
     //I wrap these for clarity
     if (player1.choice === player2.choice) {
       result = null;
     }
   
     else if (player1.choice === "rock" && player2.choice === "scissors") {
       result = player1;
     }
   
     else if (player1.choice === "scissors" && player2.choice === "paper") {
       result = player1;
     }
   
     else if (player1.choice === "paper" && player2.choice === "rock") {
       result = player1;
     }
   
     else if (player1.choice === "scissors" && player2.choice === "rock") {
       result = player2;
     }
   
     else if (player1.choice === "paper" && player2.choice === "scissors") {
       result = player2;
     }
   
     else if (player1.choice === "rock" && player2.choice === "paper") {
       result = player2;
     }
   
     return result;
   };
  const playGameObj = (player1choice, player2choice)=>{
   let player1 = {choice:player1choice} //create a new object and set choice to the argument passed in
   let player2 = {choice:player2choice}
   let winner = selectWinnerWithObj(player1,player2)
   // Use a ternary operator instead of an if in order to make it more readable 
   return (winner.choice===player1.choice)?"Player1 Wins" : "Player2 Wins"
  }
 console.log(playGameObj("rock","paper")) //Player2 Wins
 
 // /*
 // @@@@@@@@@@@@@@@@@@
 // @ Method 3       @ 
 // @@@@@@@@@@@@@@@@@@
 // Rock Paper Scissors with a data source. this handles both rock paper scissors 
 // and the future change your manager will bring to play Rock Paper Scissors Lizard Spock
 // without changing any of the code only the data source
 // it also explicitly handles ties 
 // */ 
 const selectWinner  = {
     rockscissors:"player1",
     scissorspaper:"player1",
     paperrock: "player1",
     
     scissorsrock: "player2",
     paperscissors: "player2",
     rockpaper: "player2",
     
     paperpaper: "tie",
     scissorsscissors: "tie",
     rockrock: "tie"
 }
 
 const selectWinner1  = {
     rockscissors:"player1",
     scissorspaper:"player1",
     paperrock: "player1",
     
     scissorsrock: "player2",
     paperscissors: "player2",
     rockpaper: "player2",
     
     paperpaper: "tie",
     scissorsscissors: "tie",
     rockrock: "tie",
 
     spockrock :"player1",
     spockscissors:"player1",
     lizardspock:"player1",
     lizardpaper:"player1",
 
     rockspock :"player2",
     scissorsspock :"player2",
     spocklizard :"player2",
     paperlizard :"player2",
 }
 
 const playGame = (player1, player2) => {
     // ?? Means if the left side is null use the right side 
     // "selectWinner" could have been a data source that was fed in 
     // const playGame = (player1, player2 , datasource) => { return datasource?.[player1+player2]??"Oops please enter valid options." }
     return selectWinner1?.[player1+player2]??"Oops please enter valid options."
 }
 console.log(playGame("lizard","paper")) //player1 
 
 