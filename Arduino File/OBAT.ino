
/********************************************************************
This program was developed for research purpose and open sourced to help
others that wants to trains animals in auditory discriminant tasks

Copyright (C) 2017, Mauricio Watanabe Ribeiro - 
  Edmond and Lily Safra International Institute of Neuroscience

This program is free software: you can redistribute it and/or modify it under
the terms of the GNU General Public License as published by the Free
Software Foundation, either version 3 of the License, or (at your option) any
later version.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See
the GNU General Public License for more details.
***********************************************************************/


#include <SdFat.h>         // SDFat Library
#include <SdFatUtil.h>     // SDFat Util Library
#include <SFEMP3Shield.h>  // Mp3 Shield Library
#include <SPI.h>           // Serial Peripheral Interface Library
#include <Servo.h>         // Servo Library

SdFat sd;                   // Create object to handle SD functions
SFEMP3Shield MP3player;     // Create object to handle MP3player functions

Servo leftServo;
Servo rightServo;
/*******************************************************
*
* Variables that will be received from OBTAT GUI
*
********************************************************/
int           NumberofPrimeTrials;      // Number of Primes (with only correct bar)
int           NumberofTrials;           // Number of Trials in total
int           numberIncForced;          // Number of mistakes allowed in forced session
int           TypeofRun;                // Type of Run (1- Regular, 2-Forced, 3-Regular, 4-Only Left, 5 Only Right)
unsigned long pumpTime;                 // Reward Pump Time
unsigned long TimeMax;                  // 30 min * 60 seg/min * 1000ms/seg
unsigned long interPrimeTrialTime;      // Time between prime trials
unsigned long TimeTrialMax;             // Max time allowed for trial
unsigned long interCorrTrialTime;       // Time between correct trials
unsigned long interIncorrTrialTime;     // Time between incorrect trials
unsigned long blackoutTime;             // Time of blackout insed the box after an incorrect answer

/*******************************************************
*
*  Session variables
*
********************************************************/
unsigned long TimeStart;                                   //Start time of the current session
unsigned long TimePressed;                                 //Time when the bar was pressed
unsigned long trialTimeStart;                              //Time when the trial start
unsigned long pumpStartTime;                               //Time when reward pump start
unsigned long interTrialStartTime;                         //Time when InterTrial start
unsigned long interTrialTime;                              //Time of current InterTrial: interPrime, interCorr or interIncorr


/*******************************************************
*
* Variables for use during the session
* 
********************************************************/
int            state;
int            trials;                         //number of trials occured
int            PrimeTrials;                    //number of prime trials
int            pressed;                        //pressed lever ( left, right, sim left ou sim right)
int            simuled;                        //right or left
int            res;                            //sortition result
int            forcedIncorrect;                //number of incorrect ocurred since last correct answer
int            CorrLever;                      //Correct Lever in that trial
int            IncorrLever;                    //incorrect Lever in that trial
int            eventCorr;                      
int            eventIncorr;


/******************************************************
*
* Stimulus utilized in the sessions
* 
*******************************************************/
const int NumberStimulus = 2; //Number of stimulus


char* myFiles[]={"Phee_5s.wav","Trill_5s.wav"};
unsigned long stimTime = 5000;



// For sending the name of stimulus for Log file
String stimType1 = "LEFT;";
String stimType2 = "RIGHT;";


/*******************************************************
*
* Hard configuration of pins
* 
********************************************************/

const int rightLeverPin      = 30;
const int rightBarOutPin     = 32;
const int rightLeverServoPin = 44;

const int leftLeverPin       = 26;
const int leftBarOutPin      = 28;
const int leftLeverServoPin  = 46;

const int pumpPin            = 42;
const int light              = 5;

const int eventStart         = 23;
const int eventStop          = 25;
const int eventStimRight     = 27;
const int eventStimLeft      = 29;
const int eventRightTouch    = 31;
const int eventLeftTouch     = 33;
const int eventRewardStart   = 35;
const int eventRewardStop    = 37;
const int eventBlackoutStart = 39;
const int eventBlackoutStop  = 41;
const int eventOneLever      = 43;
const int eventTwoLevers     = 45;

const int eventAudioStart    = 47;
const int eventEmpty         = 49;

/*******************************************************
*
* Position of the servo motors
* 
********************************************************/
const int outPos=130;
const int inPos=30;


/*******************************************************
*
* Strings for the buffer
* 
********************************************************/
String inString = "";    // string to hold input
String outString;


/********************************************************
*
* Counters for the pseudoRandon function
* 
********************************************************/
int list_i;
int list_j;

/******************************************************
* PSEUDORANDOM list
* List of 10 arrays, each one with 10 values
* in order to have 5 stimulus of each time per
* array and never have more than 2 repetitions
* of the same stimulus in a role
*
*******************************************************/
int list[]={0,
            1,2,1,2,2,1,2,2,1,1,
            1,2,2,1,2,1,2,1,1,2,
            2,1,1,2,2,1,2,1,2,1,
            2,1,1,2,2,1,1,2,1,2,
            2,1,2,2,2,1,1,2,1,1,
            1,2,1,2,1,2,1,1,2,2,
            2,1,1,2,2,1,2,1,2,1,
            2,1,2,1,2,2,1,1,2,1,
            1,2,2,2,1,1,2,1,2,1,
            1,2,2,1,2,1,2,2,1,1
};

void setup() {
  
  //Initiate SD Card
  sd.begin(SD_SEL, SPI_FULL_SPEED);

  //Initiate MP3 Player
  MP3player.begin();
  MP3player.setVolume(0,0);
  //The same speed choose in the GUI
  Serial.begin(9600);
  
  //Always initiate the Servo Motors in the inside position
  pinMode(rightLeverPin, INPUT);
  pinMode(rightBarOutPin, OUTPUT);
  digitalWrite(rightBarOutPin, HIGH);
  rightServo.attach(rightLeverServoPin);
  rightServo.write(inPos);
  rightServo.detach();
  digitalWrite(rightBarOutPin, LOW);
  
  //Always initiate the Servo Motors in the inside position  
  pinMode(leftBarOutPin, OUTPUT);
  digitalWrite(leftBarOutPin, HIGH);
  pinMode(leftLeverPin, INPUT);  
  leftServo.attach(leftLeverServoPin);
  leftServo.write(inPos);
  leftServo.detach();
  digitalWrite(leftBarOutPin, LOW);
  
  //Configures the pump pin  
  pinMode(pumpPin, OUTPUT);
  digitalWrite(pumpPin,LOW);

  //Configures the light pin  
  pinMode(light, OUTPUT);
  digitalWrite(light, HIGH); 
  
  pinMode(eventStart, OUTPUT);
  digitalWrite(eventStart, HIGH);
  
  pinMode(eventStop, OUTPUT);
  digitalWrite(eventStop, HIGH);

  pinMode(eventStimRight, OUTPUT);
  digitalWrite(eventStimRight, HIGH);

  pinMode(eventStimLeft, OUTPUT);
  digitalWrite(eventStimLeft, HIGH);
  
  pinMode(eventRightTouch, OUTPUT);
  digitalWrite(eventRightTouch, HIGH);
  
  pinMode(eventLeftTouch, OUTPUT);
  digitalWrite(eventLeftTouch, HIGH);
  
  pinMode(eventRewardStart, OUTPUT);
  digitalWrite(eventRewardStart, HIGH);
  
  pinMode(eventRewardStop, OUTPUT);
  digitalWrite(eventRewardStop, HIGH);

  pinMode(eventBlackoutStart, OUTPUT);
  digitalWrite(eventBlackoutStart, HIGH);

  pinMode(eventBlackoutStop, OUTPUT);
  digitalWrite(eventBlackoutStop, HIGH);

  pinMode(eventOneLever, OUTPUT);
  digitalWrite(eventOneLever, HIGH);

  pinMode(eventTwoLevers, OUTPUT);
  digitalWrite(eventTwoLevers, HIGH); 
  
  pinMode(eventAudioStart,OUTPUT);
  digitalWrite(eventAudioStart,HIGH);
  
  //if (list_i == 10) the program randonly choose a new value for j, selecting a new array of stimulus order
  list_i=10;
  list_j=0;  
  //Always initiate as 0 state
  state=0;   
}

void loop() {
  
  char inChar;
  int pos;
  

  
  while (Serial.available() > 0) {
    
      inChar = Serial.read();
      if (isDigit(inChar)) {
        inString += (char)inChar;
      }
      
      if (inChar == 'c'){
        inString = "";
      }
      
      if (inChar == 'p'){
        pumpTime=inString.toInt();
        inString = "";       
      }
      
      if (inChar == 'a'){
        TimeMax=inString.toInt();
        inString = "";       
      }
      
      if (inChar == 'b'){
        NumberofPrimeTrials=inString.toInt();
        inString = "";       
      }
      
      if (inChar == 'd'){
        NumberofTrials=inString.toInt();
        inString = "";       
      }
      
          
      if (inChar == 'f'){       
        interPrimeTrialTime=inString.toInt();
        inString = "";       
      }
      
       if (inChar == 'g'){
        interCorrTrialTime=inString.toInt();
        inString = "";       
      }
      
       if (inChar == 'h'){
        interIncorrTrialTime=inString.toInt();
        inString = "";       
      }
      
      if (inChar == 'i'){
        TimeTrialMax=inString.toInt();
        inString = "";       
      }
      
      if (inChar == 'j'){
        TypeofRun=inString.toInt();
        inString = "";       
      }
      
      if (inChar == 'm'){
        blackoutTime=inString.toInt();
        inString = "";
      }
            
      if (inChar == 'k'){
        numberIncForced=inString.toInt();
        inString = "";
      }
                
      // 't' is the start signal
      if (inChar == 's' && state == 0){
        state=1;
        inString = "";
        TimeStart=millis();
        
        digitalWrite(eventStart, LOW);
        digitalWrite(eventStart, HIGH);
        
        trials=0;
      }
      
      // 's' is the stop signal
      if (inChar == 't' && state > 0){
        state=0;
        digitalWrite(light, HIGH);
        digitalWrite(pumpPin, LOW);
        digitalWrite(eventStop, LOW);
        digitalWrite(eventStop, HIGH);     
        bothLevers(inPos);          
      }
                  
      //Left Lever Simulation
      if (inChar == 'l'){
        simuled=leftLeverPin;
        inString = "";
      }
      
      //Right Lever Simulation
      if (inChar == 'r'){
        simuled=rightLeverPin;
        inString = "";
      }
            
      //Extra reward
      if (inChar == 'w'){
        digitalWrite(pumpPin,HIGH);
        digitalWrite(eventRewardStart, LOW);
        digitalWrite(eventRewardStart, HIGH);  
        delay(pumpTime);
        digitalWrite(pumpPin,LOW);
      }
      
     }
  
  /*************************************
  * The main idea of the program is initiate at state=0
  * and when receiving the start signal "s" it goes to state =1
  * After sortition of stimulus it goes to state=2 wait for the response
  * If a response is detected before max time it goes to state=8 if correct or state=7 if incorrect
  * After the specified number of Prime Trials the program goes to next step, keeping state 8 as
  * the state after a correct response and 7 the state after an incorrect response
  * 
  *************************************/
  
  switch (state){   
    
    /*****************************************************************
    *                                                               
    * state 0 
    *
    * Do nothing, only waits the start signal (state == 1)
    *
    *****************************************************************/
    
    case 0: 
  
    break;
    
    /*****************************************************************
    *                                                               
    * state 1 - Prime trials
    *
    * Only the correct lever is shown after a stimulus is presented
    *
    *****************************************************************/
    
    case 1: //prime sortition
    
      res=pseudoRand(); //Choose stim
      

      
      /*****************************************************************
      *
      * Stimulus 1 is associated with the Left Bar
      * Stimulus 2 is associated with the Right Bar
      * 
      * In future we can add more stimulus for each bar, like a family of
      * stimulus for each bar.
      *
      *****************************************************************/
      
      if (res<=(NumberStimulus/2)){        
        digitalWrite(eventStimLeft, LOW);
        digitalWrite(eventStimLeft, HIGH);
        MP3player.playMP3(myFiles[res-1]);      
        
        delay(stimTime);       
        trialTimeStart=millis();
        simuled=0;
                
        digitalWrite(leftBarOutPin, HIGH); 
        while(leftServo.attached()==false){
          leftServo.attach(leftLeverServoPin);
        }
        leftServo.write(outPos);
        digitalWrite(eventOneLever, LOW);
        digitalWrite(eventOneLever, HIGH);        
        CorrLever=leftLeverPin;  
        eventCorr=eventLeftTouch;
        
        startString(stimType2, res, String(trialTimeStart-TimeStart), String(1));        
      }
      
      else{
        digitalWrite(eventStimRight, LOW);
        digitalWrite(eventStimRight, HIGH);
        MP3player.playMP3(myFiles[res-1]);      
        
        delay(stimTime);
        trialTimeStart=millis();
        simuled=0;
        
        digitalWrite(rightBarOutPin, HIGH); 
        while(rightServo.attached()==false){
          rightServo.attach(rightLeverServoPin);
        }    
        rightServo.write(outPos);
        digitalWrite(eventOneLever, LOW);
        digitalWrite(eventOneLever, HIGH);
        
        CorrLever=rightLeverPin;        
        eventCorr=eventRightTouch;        
        startString(stimType1, res, String(trialTimeStart-TimeStart), String(1));        
      }
      state=2;
      
    break;

    /*****************************************************************
    *                                                               
    * CASE 2 - Prime trials waiting time
    * After correct lever is shown wait the maximum allowed time
    *
    *****************************************************************/
    
    
    case 2:
    
    if (digitalRead(CorrLever)==HIGH || simuled==CorrLever){
      
      digitalWrite(eventCorr, LOW);
      digitalWrite(eventCorr, HIGH);
      
      interTrialStartTime=millis();      
      TimePressed=millis()-trialTimeStart;
      digitalWrite(pumpPin,HIGH);
      digitalWrite(eventRewardStart, LOW);
      digitalWrite(eventRewardStart, HIGH);
      pumpStartTime=millis();
      
      if (CorrLever==leftLeverPin){
        leftLever(inPos);
      }      
      else{
        rightLever(inPos);                 
      }
      
      interTrialTime=interPrimeTrialTime;     
      trials++;
      
      /***********************
      ** VALUES FOR PRESSED 
      **                    
      ** 0 - Missed         
      ** 1 - Left           
      ** 2 - Right          
      ** 3 - Simuled Left   
      ** 4 - Simuled Right  
      ************************/
      if (simuled>0){
        if (CorrLever==leftLeverPin)
          pressed=3;
        else
          pressed=4;
      }
      else{
        if (CorrLever==leftLeverPin)
          pressed=1;
        else
          pressed=2;
      }      
      finishString(String(interTrialStartTime-trialTimeStart), String(1));
      state=8;      
    }
    
    else{
      if(millis()-trialTimeStart>TimeTrialMax){
        interTrialStartTime=millis();
        TimePressed=trialTimeStart-millis();
        
        if (CorrLever==leftLeverPin){
          leftLever(inPos);       
          }
        else{
          rightLever(inPos);
        }
        
        trials++;
        interTrialTime=interPrimeTrialTime;
        
        pressed=0; //Missed trial
        finishString(String(interTrialStartTime-trialTimeStart), String(0));
        state=7;               
        
      }
      else
          if(millis()-trialTimeStart>500){
            if (rightServo.attached()==true)
              rightServo.detach();  
            if (leftServo.attached()==true)
              leftServo.detach();  
            }
          }
          
    break;
    
    /*****************************************************************
    *                                                               
    * CASE 3 - Both levers
    * Shows both lever after playing the sound
    * The diference between Regular and Forced is that after an incorrect
    * answer in the forced it will be repeated
    *
    *****************************************************************/    
    
    case 3: 
      
      if(TypeofRun==2||TypeofRun==3){
        res=pseudoRand(); //Choose stim
      }
      else{
        if (TypeofRun==4){
          res=1;
        }
        else{ 
          if (TypeofRun==5){
            res=2;
          }
        }
      }
      

      
      if (res<=(NumberStimulus/2)){
        digitalWrite(eventStimLeft, LOW);
        digitalWrite(eventStimLeft, HIGH);
        
        MP3player.playMP3(myFiles[res-1]);               //Play choosen stim
        
        simuled=0;
        forcedIncorrect=0;      
        delay (stimTime);
        trialTimeStart=millis();
        
        CorrLever=leftLeverPin;
        eventCorr=eventLeftTouch;
        
        IncorrLever=rightLeverPin;
        eventIncorr=eventRightTouch;
        
        startString(stimType2, res, String(trialTimeStart-TimeStart), String(2));        
      }
      
      else{
        digitalWrite(eventStimRight, LOW);
        digitalWrite(eventStimRight, HIGH);
        MP3player.playMP3(myFiles[res-1]);               //Play choosen stim
        
        simuled=0;
        forcedIncorrect=0;      
        delay (stimTime);
        trialTimeStart=millis();
        
        CorrLever=rightLeverPin;
        eventCorr=eventRightTouch;
        
        IncorrLever=leftLeverPin;    
        eventIncorr=eventLeftTouch;
        
        
        startString(stimType1, res, String(trialTimeStart-TimeStart), String(2));           
      }
      digitalWrite(rightBarOutPin, HIGH); 
      while(rightServo.attached()==false){
        rightServo.attach(rightLeverServoPin);
      }
      digitalWrite(leftBarOutPin, HIGH); 
      while(leftServo.attached()==false){
        leftServo.attach(leftLeverServoPin);
      }    
      rightServo.write(outPos);
      leftServo.write(outPos);
      digitalWrite(eventTwoLevers, LOW);
      digitalWrite(eventTwoLevers, HIGH);
//      bothLevers(outPos);
      
      state=5;
      
    break;
    
    /***********************************************************************
    *                                                               
    * CASE 4 - Show the lever(s) after a FORCED incorrect trial
    * After numberIncForced mistakes in a roll the animal will be 
    * presented to only the correct lever
    *
    ************************************************************************/     
    
    case 4:
    
      if ( (millis()-interTrialStartTime) > blackoutTime) {
        if(digitalRead(light)==LOW){
          digitalWrite(light, HIGH);
          digitalWrite(eventBlackoutStop, LOW);
          digitalWrite(eventBlackoutStop, HIGH);
        }
      }
      
      if ( (millis()-interTrialStartTime) > interTrialTime) {
        digitalWrite(light, HIGH); 
        if  (trials<NumberofTrials ){
          if (res<=(NumberStimulus/2)){
            digitalWrite(eventStimLeft, LOW);
            digitalWrite(eventStimLeft, HIGH);
            
            MP3player.playMP3(myFiles[res-1]);
            
            delay(stimTime);
            simuled=0;          
            trialTimeStart=millis();
            
            CorrLever=leftLeverPin;
            eventCorr=eventLeftTouch;        
            IncorrLever=rightLeverPin;
            eventIncorr=eventRightTouch;       
            
            if (forcedIncorrect>=numberIncForced){
              //leftLever(outPos);
              digitalWrite(leftBarOutPin, HIGH); 
              while(leftServo.attached()==false){
                leftServo.attach(leftLeverServoPin);
              }    
              leftServo.write(outPos);
              digitalWrite(eventOneLever, LOW);
              digitalWrite(eventOneLever, HIGH);
              startString(stimType2, res, String(trialTimeStart-TimeStart), String(1));              
            }
            else{              
              //bothLevers(outPos);
              digitalWrite(rightBarOutPin, HIGH); 
              while(rightServo.attached()==false){
                rightServo.attach(rightLeverServoPin);
              }
              digitalWrite(leftBarOutPin, HIGH);
              while(leftServo.attached()==false){
                leftServo.attach(leftLeverServoPin);
              }
              rightServo.write(outPos);
              leftServo.write(outPos);
              
              digitalWrite(eventTwoLevers, LOW);
              digitalWrite(eventTwoLevers, HIGH);
              startString(stimType2, res, String(trialTimeStart-TimeStart), String(2));
            }            
          }
          
          else{
            digitalWrite(eventStimRight, LOW);
            digitalWrite(eventStimRight, HIGH);
            
            MP3player.playMP3(myFiles[res-1]);            
            delay(stimTime);
            simuled=0;          
            trialTimeStart=millis();            
            CorrLever=rightLeverPin;
            eventCorr=eventRightTouch;
            IncorrLever=leftLeverPin;  
            eventIncorr=eventLeftTouch;
            
            if (forcedIncorrect>=numberIncForced){
              //rightLever(outPos);
              digitalWrite(rightBarOutPin, HIGH);
              while(rightServo.attached()==false){
                rightServo.attach(rightLeverServoPin);
              }                  
              rightServo.write(outPos);
              
              digitalWrite(eventOneLever, LOW);
              digitalWrite(eventOneLever, HIGH);
              
              startString(stimType1, res, String(trialTimeStart-TimeStart), String(1));                                    
            }
            else{
              //bothLevers(outPos);
              digitalWrite(rightBarOutPin, HIGH);
              while(rightServo.attached()==false){
                rightServo.attach(rightLeverServoPin);
              }
              digitalWrite(leftBarOutPin, HIGH);
              while(leftServo.attached()==false){
                leftServo.attach(leftLeverServoPin);
              }    
              rightServo.write(outPos);
              leftServo.write(outPos);
              
              digitalWrite(eventTwoLevers, LOW);
              digitalWrite(eventTwoLevers, HIGH);
              startString(stimType1, res, String(trialTimeStart-TimeStart), String(2));              
            }            
          }                    
          state=5;          
        }
        else{
          state=0;
          digitalWrite(light, HIGH);
          digitalWrite(pumpPin, LOW);
          digitalWrite(eventStop, LOW);
          digitalWrite(eventStop, HIGH);
        }
      }
    break;
    
    
    /***********************************************************************
    *                                                               
    * CASE 5 - Waiting time with both levers
    * The diference between Regular and Forced is that after an incorrect
    * answer in the forced it will be repeated, wich mean be sent to CASE 4
    * where the trail will be repeted instead to CASE 3 for a new sortition.
    *
    ************************************************************************/    
    
    case 5: //Aguarda resposta para ambas alavancas (Forced ou regular)
      
      if (digitalRead(CorrLever)==HIGH || simuled==CorrLever){
        
        digitalWrite(eventCorr, LOW);
        digitalWrite(eventCorr, HIGH);
        
        digitalWrite(pumpPin,HIGH);
        
        digitalWrite(eventRewardStart, LOW);
        digitalWrite(eventRewardStart, HIGH);
        
        pumpStartTime=millis();
        interTrialStartTime=millis();
        TimePressed=trialTimeStart-millis();        
        bothLevers(inPos);                
        interTrialTime=interCorrTrialTime;
        
        /***********************
        ** VALUES FOR PRESSED 
        **                    
        ** 0 - Missed         
        ** 1 - Left           
        ** 2 - Right          
        ** 3 - Simuled Left   
        ** 4 - Simuled Right  
        ************************/
        if (simuled>0){
          if (CorrLever==leftLeverPin)
            pressed=3;
          else
            pressed=4;
        }
        else{
          if (CorrLever==leftLeverPin)
            pressed=1;
          else
            pressed=2;
        }
       
       
       
       
        
        finishString(String(interTrialStartTime-trialTimeStart), String(1));        
        trials++;
        state=8;        
      }
      
      else{
        if (digitalRead(IncorrLever)==HIGH || simuled==IncorrLever){
            
            digitalWrite(eventIncorr, LOW);
            digitalWrite(eventIncorr, HIGH);
            
            bothLevers (inPos);          
            interTrialStartTime=millis();
            TimePressed=trialTimeStart-millis();
            
            
            /***********************
            ** VALUES FOR PRESSED 
            **                    
            ** 0 - Missed         
            ** 1 - Left           
            ** 2 - Right          
            ** 3 - Simuled Left   
            ** 4 - Simuled Right  
            ************************/
            if (simuled>0){
              if (IncorrLever==leftLeverPin)
                pressed=3;
              else
                pressed=4;
            }
            else{
              if (IncorrLever==leftLeverPin)
                pressed=1;
              else
                pressed=2;
            }
            
            interTrialTime=interIncorrTrialTime;
            finishString(String(interTrialStartTime-trialTimeStart), String(0));          
            
            digitalWrite(light, LOW);
            digitalWrite(eventBlackoutStart, LOW);
            digitalWrite(eventBlackoutStart, HIGH);
            
            trials++;
                        
            if(TypeofRun==2){ //Forced, so after a mistake there are no new sortition
              forcedIncorrect=forcedIncorrect+1;
              state=4;
            }
            else
            {
              state=7;
            } 
        }
        
        else{
          if(millis()-trialTimeStart>TimeTrialMax){
            interTrialStartTime=millis();
            TimePressed=trialTimeStart-millis();        
            pressed=0; //It means the animal missed this trial                             
            bothLevers(inPos);            
            trials++;        
            
            digitalWrite(light, LOW);
            digitalWrite(eventBlackoutStart, LOW);
            digitalWrite(eventBlackoutStart, HIGH);
            
            
            interTrialTime=interIncorrTrialTime;                                      
            state=7;
            finishString(String(interTrialStartTime-trialTimeStart), String(0));
          }
          else
          if(millis()-trialTimeStart>500){            
            if (rightServo.attached()==true)
              rightServo.detach();  
            if (leftServo.attached()==true)
              leftServo.detach();
          }
        }
      }
    break;
          
    case 7: // Waits the specified time before the next trial
      
      if ( (millis()-interTrialStartTime) > blackoutTime ) {  
        if (digitalRead(light)==LOW){
          digitalWrite(light, HIGH);
          digitalWrite(eventBlackoutStop, LOW);
          digitalWrite(eventBlackoutStop, HIGH);
        }
      }
         
      if ( (millis()-interTrialStartTime) > interTrialTime) {            
        
        if (digitalRead(light)==LOW){              
          digitalWrite(light, HIGH);
        }
        if (trials<NumberofPrimeTrials){
          state=1;
        }
        else{
          if(trials<(NumberofPrimeTrials+NumberofTrials))
            state=3;
          if (trials>=(NumberofPrimeTrials+NumberofTrials)||TypeofRun==1){
            digitalWrite(eventStop, LOW);
            digitalWrite(eventStop, HIGH);
            state=0;
            PrimeTrials=0;
            trials=0;
          }
        }
      }
      
      if (TimeMax<(millis()-TimeStart)){
        digitalWrite(eventStop, LOW);
        digitalWrite(eventStop, HIGH);
        state=0;
        PrimeTrials=0;
        trials=0;
      }
      
    break;
    
    
    
    //Reward pump stop after specified time
    case 8:
      if ((millis()-pumpStartTime)>=pumpTime){
          digitalWrite(pumpPin,LOW);
          state=7;
        }
    break;
  }
}

/***********************************************
* 
* pseudo random sortition, because Arduino random is not perfectly random
*
************************************************/

int pseudoRand(){
  int res;
  if (list_i>=10){
      list_i=1;
      randomSeed(millis());
      list_j=random(10); // This number goes from 0-9, that will be multiplied by 10 and add with list_i
                         // to the be then utilized as stimulus number at the the list[]
  }
  res=list[list_i+10*list_j];
  list_i=list_i+1;
  return res;
}

/***********************************************
* 
* Retract both levers
*
************************************************/

void bothLevers(int pos){  
  while(leftServo.attached()==false){
    leftServo.attach(leftLeverServoPin);
  }  
  while(rightServo.attached()==false){
    rightServo.attach(rightLeverServoPin);
  }  
  leftServo.write(pos);
  rightServo.write(pos);           
  delay(500);          
  rightServo.detach();
  digitalWrite(rightBarOutPin, LOW); 
  leftServo.detach();
  digitalWrite(leftBarOutPin, LOW); 
}

/***********************************************
* 
* Retract left lever
*
************************************************/
void leftLever(int pos){  
  while(leftServo.attached()==false){
    leftServo.attach(leftLeverServoPin);
  }    
  leftServo.write(pos);  
  delay(500);          
  leftServo.detach();     
  digitalWrite(leftBarOutPin, LOW); 
}

/***********************************************
* 
* Retract right lever
*
************************************************/
void rightLever(int pos){  
  while(rightServo.attached()==false){
    rightServo.attach(rightLeverServoPin);
  }  
  rightServo.write(pos);           
  delay(500);          
  rightServo.detach();  
  digitalWrite(rightBarOutPin, LOW); 
}

/*******************************************************
*
*  The string start after the stimulus is played
*
********************************************************/
void startString(String stimType, int res, String StimStartTime, String NumberofLevers){  
  outString=stimType;                    // Type Stimulus  
  outString+=myFiles[res-1];             // Stimulus File  
  outString+=";";
  outString+=StimStartTime;              // Time Stimulus Start  
  outString+=";";  
  outString+=NumberofLevers;             // Type of Trial - 1 or 2 levers  
  outString+=";";  
}

/*******************************************************
*
*  The string finishes after the animal press a bar and 
*  is then sent to the host computer
*
********************************************************/
void finishString(String PressedTime, String IsCorrect){
            
  outString+=pressed;                               // Wich lever was pressed
  outString+=";";
  outString+=PressedTime;                           // Time spend between stimulus and lever being pressed
  outString+=";";
  outString+=IsCorrect;                             // isCorrect? (0 = False or 1 = True)
  outString+=";";
  Serial.println(outString);
}
