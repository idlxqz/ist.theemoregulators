﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class GlobalizationService  {

    #region singleton pattern
    private static GlobalizationService instance = null;

    public static GlobalizationService Instance
    {
        get
        {
            if (instance == null) instance = new GlobalizationService();
            return instance;
        }
    }
    #endregion

    private Dictionary<string, Dictionary<SystemLanguage, string>> multiLanguageDictionary; 

    public SystemLanguage CurrentLanguage { get; private set; }

    #region Globalization Constants
    public const string ContinueButton = "ContinueButton";
    public const string OpeningTitle = "OpeningTitle";
    public const string OpeningAText = "OpeningAText";
    public const string OpeningBText = "OpeningBText";
    public const string OpeningCText = "OpeningCText";
    public const string OpeningDText = "OpeningDText";
    public const string OpeningEText = "OpeningEText";
    public const string OpeningFText = "OpeningFText";
    public const string IntroducingOurselvesTitle = "IntroducingOurselvesTitle";
    public const string IntroducingOurselvesAText = "IntroducingOurselvesAText";
    public const string IntroducingOurselvesBText = "IntroducingOurselvesBText";
    public const string IBoxIntroductionTitle = "IBoxIntroductionTitle";
    public const string IBoxIntroductionAText = "IBoxIntroductionAText";
    public const string IBoxIntroductionBText = "IBoxIntroductionBText";
    #endregion

    public string Globalize(string globalizationKey)
    {
        //if the globalization key is not found, return the received key
        var dictionary = this.multiLanguageDictionary[globalizationKey];
        if (dictionary == null) return globalizationKey;

        var globalizedResult = dictionary[this.CurrentLanguage];
        //if there is no translation for the current language, return the translation for the firt language found
        if (globalizedResult == null) return dictionary.Values.FirstOrDefault();
        return globalizedResult;
    }

    private GlobalizationService()
    {
        this.CurrentLanguage = SystemLanguage.English;

        this.multiLanguageDictionary = new Dictionary<string, Dictionary<SystemLanguage, string>>();

        this.multiLanguageDictionary.Add(ContinueButton, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Continue"},
            {SystemLanguage.Italian, "Continuare"}
        });

        this.multiLanguageDictionary.Add(OpeningTitle, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Introduction"},
            {SystemLanguage.Italian, "Introduzione"}
        });

        this.multiLanguageDictionary.Add(OpeningAText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Hi!\nWelcome to Emoregulator, the game to learn how to handle stress and to regulate our emotions.\nOften we have to cope with situations that make us feeling stressed and that put us a little in trouble ...\nMaybe for an important exam, or because we discuss with our parents, or because we have too many things to do all at once!\nSo, we are getting nervous, we don't know what is the best to do ... we feel stomachache, headache and we don't find the solution..."},
            {SystemLanguage.Italian, "Ciao!\nBenvenuto(a) a Emoregulator, il gioco per imparare a gestire lo stress e le nostre emozioni.\n\nSpesso ci troviamo ad affrontare situazioni che ci agitano e ci mettono un po' in difficoltà...\nMagari per una verifica importante, oppure perchè discutiamo con i nostri genitori, o perchè abbiamo troppe cose da fare tutte insieme! Così, ci innervosiamo, non sappiamo cosa è meglio fare...cominciamo a sentire un gran mal di pancia, ci viene il mal di testa e non troviamo soluzione..."}
        });

        this.multiLanguageDictionary.Add(OpeningBText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Today we will learn to recognize what happens to our bodies when we are a bit nervous, and together we will see also how to better handle all these sensations.\n\nBut...we will do it having fun, playing!\n\nYes, in fact Emoregulator is a game developed for people of your age. So, today you will do different activities, some directly at the computer, other externally. Soon, you will know your avatar and he will do exactly the same as you do. You will give him the name that you want, in fact, the avatar is yourself."},
            {SystemLanguage.Italian, "Oggi impareremo a riconoscere ciò che succede al nostro corpo quando siamo un po' agitati, e vedremo insieme anche come gestire meglio tutte queste sensazioni.\n\nPerò...lo faremo divertendoci, giocando!\n\nEh sì, infatti Emoregulator è un gioco, sviluppato per i ragazzi della tua età. Oggi quindi farai diverse attività, alcune direttamente a computer, altre esternamente. Tra poco conoscerai il tuo avatar e lui farà esattamente lo stesso che farai tu(e). Potrai dargli il nome che vuoi, infatti l'avatar rappresenta te stesso(a). In altre parole, sarai tu(e), dentro al gioco!"}
        });

        this.multiLanguageDictionary.Add(OpeningCText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Before each level, you will find the written instructions of what you have to do.\nAlso, as you saw, you were equipped with some physiological sensors.\nWe will not do any medical examinations ;-).\nThrough the sensors you can see how you are improving in your ability to manage anxiety.\nYou will see your heart rate, and more you will be good, more points you'll get!\n\nThe game consists of several levels, to move to the next one, you should always complete the previous one and then click on the continue button."},
            {SystemLanguage.Italian, "Prima di ogni livello, troverai le istruzioni scritte di ciò che dovrai fare.\nInoltre, come hai visto, sei stato(a) dotato(a) di alcuni sensori fisiologici.\nNon vogliamo farti degli esami medici ;-)\nServiranno a te perchè così potrai vedere come stai migliorando nella tua capacità di gestire l'ansia.\nPotrai vedere il tuo battito cardiaco, e più sarai bravo, più punti guadagnerai!\n\nIl gioco si compone di diversi livelli, per passare al seguente, dovrai sempre completare quello che precedente e poi, cliccare in tasto continuare."}
        });

        this.multiLanguageDictionary.Add(OpeningDText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Each time you will complete an exercise, you'll earn points.\nAt each level the difficulty will increase, so you can earn more and more!\nAt the top left you will see the points that you can achieve and then, those that actually you have received.\nIn this way, your avatar will become stronger and more skilled in dealing with stress and manage emotions!"},
            {SystemLanguage.Italian, "Ogni volta che porterai a termine un esercizio, guadagnerai dei punti.\nAd ogni livello aumenterà la difficoltà, per cui potrai guadagnare sempre di più!\nIn alto a sinistra vedrai i punti che potresti raggiungere e poi, quelli che effettivamente riesci a prendere.\nIl tuo avatar diventerà così sempre più forte e più bravo nell'affrontare lo stress e gestire le emozioni!."}
        });

        this.multiLanguageDictionary.Add(OpeningEText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "At the beginning and at the end of the next session, you will find the M&M, your ME-METER. It it will be your thermomether to measure how much you will improve your ability to relax.\nLet's see how much good you will be!"},
            {SystemLanguage.Italian, "All'inizio ed alla fine della prossima sessione, troverai l' M&M, il tuo ME-METER. Questo sarà il tuo termometro per misurare quanto migliorerai la tua capacità di rilassamento.\nVediamo un po' quanto sarai bravo!"}
        });
        
        this.multiLanguageDictionary.Add(OpeningFText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Last information ...\nOnce you start exercising, you can always click on the icon in the lower right and read again the instructions.\nNow, it's time to have fun!\nCome on, let's start!"},
            {SystemLanguage.Italian, "Ultima informazione...\nUna volta iniziato l'esercizio, potrai sempre cliccare sull'icona in basso a destra e rileggere le istruzioni.\nOra, direi che è arrivato il momento di divertirci!\nForza, iniziamo!"}
        });

        this.multiLanguageDictionary.Add(IntroducingOurselvesTitle, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "My avatar"},
            {SystemLanguage.Italian, "Il mio avatar"}
        });

        this.multiLanguageDictionary.Add(IntroducingOurselvesAText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "First of all you have to choose the background that you want to give to the game.\nHere are various options.\nClick on the image.\nPerfect!"},
            {SystemLanguage.Italian, "Prima di tutto scegli lo sfondo che vuoi dare al gioco.\nQui trovi varie opzioni.\nClicca sopra l'immagine.\nPerfetto!"}
        });

        this.multiLanguageDictionary.Add(IntroducingOurselvesBText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Now, we have to create your own avatar!\nThis is you.\nGive him/her a name!\nYou can choose what you want, your real name, or a different one.\nEvery time you will complete an exercise, you will become stronger.\nThen click on √ and let's continue our game!"},
            {SystemLanguage.Italian, "Ora, invece, creiamo il tuo avatar!\nQuesto sei tu.\nDagli un un nome!\nPuoi scegliere quello che vuoi, il tuo vero nome, o inventarne un altro.\nOgni volta che terminerai un esercizio diventerai più forte\nPoi clicca su √ e prosegui nel nostro gioco!"}
        });

        this.multiLanguageDictionary.Add(IBoxIntroductionTitle, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "I-Box"},
            {SystemLanguage.Italian, "I-Box"}
        });

        this.multiLanguageDictionary.Add(IBoxIntroductionAText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Another thing to know before starting our game ...\n\nThis is your I-box.\nIt's your personal space, where you collect points that you will be able to earn.\nHere also, you can put anything you will create during the exercises.\nYou can color the I-box as desired.\nMoreover it will always be at the top left.\nNext to the I-BOX you'll see your heartbeats, next to the hearth symbol."},
            {SystemLanguage.Italian, "Esther, please write down this part in italian please."}
        });

        this.multiLanguageDictionary.Add(IBoxIntroductionBText, new Dictionary<SystemLanguage, string>
        {
            {SystemLanguage.English, "Well!\nWe are ready to start having fun! Click to continue."},
            {SystemLanguage.Italian, "Esther, please write down this part in italian please."}
        });
    }

    
}
