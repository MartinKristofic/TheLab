using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // BRUTALNO DUGA SKRIPTA NAMJENJENA UPRAVLJANJEM IGRICE

    public TextMeshProUGUI collisionValue;

    public float counter;

    public float timer; // univerzalna varijabla za brojanje proteklog vremena, koristi se u Sandboxu, Simulaciji Kemije i Biologije

    public int currentScene; // varijabla koja prati index trenutne scene

    public int touchingNeon; // dodaje vrijednost 1 za svaki neon koji se dodiruje s strujom i oduzima 1 kad se prestane dodirivati

    public Camera cam; // glavna kamera

    public Slider sliderA;
    public AtomBehaviour[] activeAtoms;

    public Slider sliderB;
    public AtomBehaviour2[] activeAtoms2;

    // varijable koje se update-aju svaki frame i govore koliki je broj razlicitih elemenata/partikli na ekranu
    public int numberOfNeon;
    public int numberOfHydrogen;
    public int numberOfWater;
    public int numberOfLithium;
    public int numberOfOxygen;

    // zbroj svih elemenata na ekranu, takodjer se update-a svaki frame
    public int numberOfElements;

    public Vector2 mousePos = new Vector2();
    public Vector3 pozicija = new Vector3();

    public GameObject blocker;

    public GameObject fire;
    public GameObject ice;
    public GameObject elec;
    public GameObject eraser;

    public GameObject neon;
    public GameObject water;
    public GameObject hydrogen;
    public GameObject lithium;
    public GameObject oxygen;

    public bool fireON= false;
    public bool iceON = false;
    public bool elecON = false;
    public bool eraserON = false;

    public bool neonON = false;
    public bool waterON = false;
    public bool hydrogenON = false;
    public bool lithiumON = false;
    public bool oxygenON = false;

    public TextMeshProUGUI questionNumber;
    public TextMeshProUGUI questionText;

    public Image button0;
    public Image button1;
    public Image button2;

    public TextMeshProUGUI button0text;
    public TextMeshProUGUI button1text;
    public TextMeshProUGUI button2text;

    public TextMeshProUGUI questionCounter;

    public GameObject objectOnScreen0;
    public GameObject objectOnScreen2;

    public int numberOfQuestions;

    private GameObject[] numberOfCreatures;
    private GameObject[] numberOfFood;

    public Slider sliderZaPopulaciju;
    public Slider sliderZaHranu;
    public TextMeshProUGUI textZaPopulaciju;
    public GameObject creature;

    public TextMeshProUGUI textZaHranu;
    public GameObject food;
    public bool foodbc;

    public GameObject blockade;
    public GameObject wallNorth;
    public GameObject wallSouth;
    public GameObject wallWest;

    private int numberOfCreaturesL;
    public bool isAllowedToLive;

    public TextMeshProUGUI generationText;
    public int generationNum;

    public GameObject numberOfFoodObj;
    public GameObject numberOfCreaturesObj;

    public int numberOfFoodTEMP;

    public GameObject speedUpOptions;
    public int speedUpFactor; // odabire koliko puta mora simulacija biti brza

    public AudioSource src;
    public GameObject ExitButton;

    private void Start()
    {
        touchingNeon = 0;
        timer = 0f;
        numberOfQuestions = 1;
        numberOfCreaturesL = 0;
        generationNum = 1;

        speedUpFactor = 1;

        isAllowedToLive = false;

        currentScene = SceneManager.GetActiveScene().buildIndex;
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        if (currentScene == 6)
        {
            creature.GetComponent<CreatureScript>().size = 1;
            creature.GetComponent<CreatureScript>().speed = 1;

            numberOfCreatures = GameObject.FindGameObjectsWithTag("Creature");
            numberOfFood = GameObject.FindGameObjectsWithTag("Food");
        }
    }

    public void Update()
    {
        if (currentScene == 6) // re-used vecina koda iz SliderScript.cs za spawnanje atoma
        {
            numberOfCreatures = GameObject.FindGameObjectsWithTag("Creature");
            numberOfCreaturesL = numberOfCreatures.Length;

            textZaPopulaciju.text = sliderZaPopulaciju.value.ToString();

            if (!isAllowedToLive)
            {
                speedUpOptions.SetActive(false);

                if (int.Parse(textZaPopulaciju.text) != numberOfCreaturesL && numberOfCreaturesL < int.Parse(textZaPopulaciju.text))
                {
                    if (numberOfCreaturesL < 10)
                    {
                        Instantiate(creature, new Vector2(-(numberOfCreaturesL % 10) * 0.75f + 1f, wallNorth.transform.position.y - 0.5f), Quaternion.identity);
                    }
                    else if (numberOfCreaturesL < 20)
                    {
                        Instantiate(creature, new Vector2(-(numberOfCreaturesL % 10) * 0.75f + 1f, wallNorth.transform.position.y - 1.5f), Quaternion.identity);
                    }
                    else if (numberOfCreaturesL < 30)
                    {
                        Instantiate(creature, new Vector2(-(numberOfCreaturesL % 10) * 0.75f + 1f, wallSouth.transform.position.y + 0.5f), Quaternion.identity);
                    }
                    else if (numberOfCreaturesL < 40)
                    {
                        Instantiate(creature, new Vector2(-(numberOfCreaturesL % 10) * 0.75f + 1f, wallSouth.transform.position.y + 1.5f), Quaternion.identity);
                    }
                    else if (numberOfCreaturesL < 50)
                    {
                        Instantiate(creature, new Vector2(-(numberOfCreaturesL % 10) * 0.75f + 1f, wallSouth.transform.position.y + 2.5f), Quaternion.identity);
                    }
                }
                else if (int.Parse(textZaPopulaciju.text) != numberOfCreaturesL && numberOfCreaturesL > int.Parse(textZaPopulaciju.text))
                {
                    Destroy(numberOfCreatures[numberOfCreatures.Length - 1]);
                }

                numberOfFood = GameObject.FindGameObjectsWithTag("Food");
                numberOfFoodTEMP = (int)sliderZaHranu.value; // temp varijabla za broj hrane kroz generacije

                if (int.Parse(textZaHranu.text) != numberOfFood.Length && numberOfFood.Length < int.Parse(textZaHranu.text))
                {
                    Instantiate(food, new Vector2(1 * Random.Range(wallWest.transform.position.x + 0.5f, blockade.transform.position.x - 0.5f), 1 * Random.Range(wallSouth.transform.position.y + 4f, wallNorth.transform.position.y - 2.5f)), Quaternion.identity);
                }
                else if (int.Parse(textZaHranu.text) != numberOfFood.Length && numberOfFood.Length > int.Parse(textZaHranu.text))
                {
                    Destroy(numberOfFood[numberOfFood.Length - 1]);
                }

                foodbc = false;
            }
            else
            {
                foodbc = true;
                speedUpOptions.SetActive(true);

                numberOfCreatures = GameObject.FindGameObjectsWithTag("Creature");
                numberOfFood = GameObject.FindGameObjectsWithTag("Food");

                if (numberOfFood.Length == 0 && numberOfCreatures.Length == 0)
                {
                    StopNaturalSelection();
                }
                else if (numberOfFood.Length == 0)
                {
                    generationNum++;
                    generationText.text = "GENERACIJA: " + generationNum.ToString();

                    GenerateFood(); // generira onoliko hrane koliko je korisnik odabrao na pocetku
                    TeleportToDefaultPositionsAndInheritGenes(); // teleportira prezivijele na pocetne pozicije i naslijedjuje genetiku
                    timer = 0;
                }
                else if (numberOfCreatures.Length == 0)
                {
                    Invoke("StopNaturalSelection", 1f);
                    timer = 0;
                }
                else if (timer > 20f / speedUpFactor)
                {
                    generationNum++;
                    generationText.text = "GENERACIJA: " + generationNum.ToString();

                    GenerateFood(); // generira onoliko hrane koliko je korisnik odabrao na pocetku
                    TeleportToDefaultPositionsAndInheritGenes(); // teleportira prezivijele na pocetne pozicije i naslijedjuje genetiku
                    timer = 0;
                }

                timer += Time.deltaTime;

            }
        }
        else if (currentScene == 4) // sistem postavljanja pitanja vezane uz brzinu kemijskih reakcija
        {
            if (numberOfQuestions == 1)
            {
                questionNumber.text = "PITANJE BROJ " + numberOfQuestions.ToString() + ":";
                questionText.text = "Koji od navedenih odgovora " + "<b>" + "ne" + "</b>" + " ubrzava/usporava kemijsku reakciju?";

                button0text.text = "Veli\u010dina atoma"; // \u10d je vrijednost slova tvrdog c u hex-u
                button1text.text = "Naboj";
                button2text.text = "Pritisak";
            }
            else if (numberOfQuestions == 2)
            {
                questionNumber.text = "PITANJE BROJ " + numberOfQuestions.ToString() + ":";
                questionText.text = "Ako smanjimo pritisak, kakva \u0107e biti brzina kemijske reakcije?"; // \u107 je vrijednost slova mekog c u hex-u

                button0text.text = "Manja";
                button1text.text = "Ve\u0107a";
                button2text.text = "Ista";
            }
            else if (numberOfQuestions == 3)
            {
                questionNumber.text = "PITANJE BROJ " + numberOfQuestions.ToString() + ":";
                questionText.text = "Koja je jedna od dvije mjerne jedinice za temperaturu?";

                button0text.text = "Kulon";
                button1text.text = "Kilogram";
                button2text.text = "Kelvin";
            }
            else if (numberOfQuestions == 4)
            {
                EndQuestionSection();
            }

            if(numberOfQuestions < 4)
            {
                questionCounter.text = numberOfQuestions.ToString() + "/3";
            }

        }
        else if (currentScene == 3)
        {
            activeAtoms = FindObjectsOfType<AtomBehaviour>();
            activeAtoms2 = FindObjectsOfType<AtomBehaviour2>();

            foreach (AtomBehaviour atom in activeAtoms)
            {
                if (sliderA.value != 0)
                {
                    atom.gameObject.transform.localScale = new Vector2(sliderA.value, sliderA.value);
                }
                else
                {
                    atom.gameObject.transform.localScale = new Vector2(0.4f, 0.4f);
                }
            }

            foreach (AtomBehaviour2 atom in activeAtoms2)
            {
                if (sliderB.value != 0)
                {
                    atom.gameObject.transform.localScale = new Vector2(sliderB.value, sliderB.value);
                }
                else
                {
                    atom.gameObject.transform.localScale = new Vector2(0.4f, 0.4f);
                }
            }

            if (timer > 1f)
            {
                collisionValue.text = "Broj sudara/s: " + ((int)counter).ToString();
                timer = 0;
                counter = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else if (currentScene == 2) // sistem za kontrolu sandbox-a
        {
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            pozicija = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

            numberOfHydrogen = FindObjectsOfType<HydrogenBehaviour>().Length;
            numberOfLithium = FindObjectsOfType<LithiumBehaviour>().Length;
            numberOfWater= FindObjectsOfType<WaterChangeStates>().Length;
            numberOfNeon = FindObjectsOfType<NeonBehaviour>().Length;
            numberOfOxygen = FindObjectsOfType<OxygenBehaviour>().Length;

            numberOfElements = numberOfHydrogen + numberOfWater + numberOfNeon + numberOfLithium + numberOfOxygen;

            timer += Time.deltaTime;

            if (fireON)
            {
                if (pozicija.x < blocker.transform.position.x - 0.64f)
                {
                    fire.transform.position = pozicija;
                }

                if (ice.transform.position.x != 1000 || elec.transform.position.x != 1000 || eraser.transform.position.x != 1000)
                {
                    ice.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                    eraser.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                    elec.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                }

                ice.SetActive(false);
                eraser.SetActive(false);
            }
            else if (iceON)
            {
                if (pozicija.x < blocker.transform.position.x - 0.64f)
                {
                    ice.transform.position = pozicija;
                }

                if (fire.transform.position.x != 1000 || elec.transform.position.x != 1000 || eraser.transform.position.x != 1000)
                {
                    fire.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                    eraser.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                    elec.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                }

                fire.SetActive(false);
                eraser.SetActive(false);
            }
            else if (elecON)
            {
                if (pozicija.x < blocker.transform.position.x - 0.64f)
                {
                    elec.transform.position = pozicija;
                }

                if (fire.transform.position.x != 1000 || ice.transform.position.x != 1000 || eraser.transform.position.x != 1000)
                {
                    ice.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                    eraser.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                    fire.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                }

                fire.SetActive(false);
                ice.SetActive(false);
                eraser.SetActive(false);
            }
            else if (eraserON)
            {
                if (pozicija.x < blocker.transform.position.x - 0.64f)
                {
                    eraser.transform.position = pozicija;
                }

                if (fire.transform.position.x != 1000 || ice.transform.position.x != 1000 || elec.transform.position.x != 1000)
                {
                    ice.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                    elec.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                    fire.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
                }

                fire.SetActive(false);
                ice.SetActive(false);
            }
            else if (hydrogenON)
            {
                if (Input.touchCount > 0 && pozicija.x < blocker.transform.position.x - 0.64f && numberOfElements < 150)
                {
                    if (timer > 0.05f)
                    {
                        Instantiate(hydrogen, pozicija, Quaternion.identity);
                        timer = 0f;
                    }  
                }

                DeaktivirajElse();

                if (fire.transform.position.x != 1000 || ice.transform.position.x != 1000 || elec.transform.position.x != 1000 || eraser.transform.position.x != 1000)
                {
                    PromjeniTransform();
                }
            }
            else if (waterON)
            {
                if (Input.touchCount > 0 && pozicija.x < blocker.transform.position.x - 0.64f && numberOfElements < 150)
                {
                    if (timer > 0.05f)
                    {
                        Instantiate(water, pozicija, Quaternion.identity);
                        timer = 0f;
                    }
                }

                DeaktivirajElse();

                if (fire.transform.position.x != 1000 || ice.transform.position.x != 1000 || elec.transform.position.x != 1000 || eraser.transform.position.x != 1000)
                {
                    PromjeniTransform();
                }
            }
            else if (lithiumON)
            {
                if (Input.touchCount > 0 && pozicija.x < blocker.transform.position.x - 0.64f && numberOfElements < 150)
                {
                    if (timer > 0.05f)
                    {
                        Instantiate(lithium, pozicija, Quaternion.identity);
                        timer = 0f;
                    }
                }

                DeaktivirajElse();

                if (fire.transform.position.x != 1000 || ice.transform.position.x != 1000 || elec.transform.position.x != 1000 || eraser.transform.position.x != 1000)
                {
                    PromjeniTransform();
                }
            }
            else if (neonON)
            {
                if (Input.touchCount > 0 && pozicija.x < blocker.transform.position.x - 0.64f && numberOfElements < 150)
                {
                    if (timer > 0.05f)
                    {
                        Instantiate(neon, pozicija, Quaternion.identity);
                        timer = 0f;
                    }
                }

                DeaktivirajElse();

                if (fire.transform.position.x != 1000 || ice.transform.position.x != 1000 || elec.transform.position.x != 1000 || eraser.transform.position.x != 1000)
                {
                    PromjeniTransform();
                }
            }
            else if (oxygenON)
            {
                if (Input.touchCount > 0 && pozicija.x < blocker.transform.position.x - 0.64f && numberOfElements < 150)
                {
                    if (timer > 0.05f)
                    {
                        Instantiate(oxygen, pozicija, Quaternion.identity);
                        timer = 0f;
                    }
                }

                DeaktivirajElse();

                if (fire.transform.position.x != 1000 || ice.transform.position.x != 1000 || elec.transform.position.x != 1000 || eraser.transform.position.x != 1000)
                {
                    PromjeniTransform();
                }
            }
        }
    }

    void DeaktivirajElse()
    {
        fire.SetActive(false);
        ice.SetActive(false);
        eraser.SetActive(false);
    }

    void PromjeniTransform() // stavlja poziciju razreda "ostalo", daleko na x os
    {
        ice.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
        elec.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
        fire.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
        eraser.transform.position = new Vector3(1000, 0, cam.nearClipPlane);
    }

    public void StartNaturalSelection()
    {
        isAllowedToLive = true;

        numberOfCreaturesObj.SetActive(false);
        numberOfFoodObj.SetActive(false);
    }

    public void StopNaturalSelection()
    {
        isAllowedToLive = false;

        sliderZaPopulaciju.value = 0;
        sliderZaHranu.value = 0;

        speedUpFactor = 1; // vraca brzinu progresije simulacije nazad na 1x

        creature.GetComponent<CreatureScript>().size = 1;
        creature.GetComponent<CreatureScript>().speed = 1;

        generationNum = 1;
        generationText.text = "GENERACIJA: " + generationNum.ToString();

        numberOfCreaturesObj.SetActive(true);
        numberOfFoodObj.SetActive(true);
    }

    public void GenerateFood()
    {
        for (int i = numberOfFood.Length; i < numberOfFoodTEMP; i++)
        {
            Instantiate(food, new Vector2(1 * Random.Range(wallWest.transform.position.x + 0.5f, blockade.transform.position.x - 0.5f), 1 * Random.Range(wallSouth.transform.position.y + 4f, wallNorth.transform.position.y - 2.5f)), Quaternion.identity);
        }
    }

    public void TeleportToDefaultPositionsAndInheritGenes() // UPOZORENJE! Sadrzi spaghetti kod...
    {
        KillAllUnfit(); // ubija sve koji nisu jeli i pirprema druge za iduci krug

        int randomNum;

        for (int i = 0; i < numberOfCreatures.Length - Unfit; i++)
        {
            randomNum = Random.Range(0, 20); // 10% sanse za mutaciju (2 od 20)

            if (i < 10)
            {
                Instantiate(Modify(creature, randomNum, i), new Vector3(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallNorth.transform.position.y - 0.5f, 1), Quaternion.identity);
                numberOfCreatures[i].transform.position = new Vector2(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallNorth.transform.position.y - 0.5f);
            }
            else if (i < 20)
            {
                Instantiate(Modify(creature, randomNum, i), new Vector3(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallNorth.transform.position.y - 1.5f, 1), Quaternion.identity);
                numberOfCreatures[i].transform.position = new Vector2(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallNorth.transform.position.y - 1.5f);
            }
            else if (i < 30)
            {
                Instantiate(Modify(creature, randomNum, i), new Vector3(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallSouth.transform.position.y + 0.5f, 1), Quaternion.identity);
                numberOfCreatures[i].transform.position = new Vector2(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallSouth.transform.position.y + 0.5f);
            }
            else if (i < 40)
            {
                Instantiate(Modify(creature, randomNum, i), new Vector3(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallSouth.transform.position.y + 1.5f, 1), Quaternion.identity);
                numberOfCreatures[i].transform.position = new Vector2(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallSouth.transform.position.y + 1.5f);
            }
            else if (i < 50)
            {
                Instantiate(Modify(creature, randomNum, i), new Vector3(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallSouth.transform.position.y + 2.5f, 1), Quaternion.identity);
                numberOfCreatures[i].transform.position = new Vector2(-(numberOfCreatures.Length % 10) * 0.75f - 1f, wallSouth.transform.position.y + 2.5f);
            }

            if (numberOfCreatures[i].transform.position.x < wallWest.transform.position.x || numberOfCreatures[i].transform.position.y > wallNorth.transform.position.y)
            {
                numberOfCreatures[i].transform.position = new Vector2(wallWest.transform.position.x + 2f, wallSouth.transform.position.y + 1f);
            }
            else if (numberOfCreatures[i].transform.position.x > blockade.transform.position.x)
            {
                numberOfCreatures[i].transform.position = new Vector2(wallWest.transform.position.x + 2f, wallSouth.transform.position.y + 1f);
            }
        }

        Unfit = 0;
        Invoke("CheckAgain", 0.25f); // invoke, moju genijalnu skrptu napravljenu za provijeru teleportiranih obijekata
    }

    public int Unfit;

    public void KillAllUnfit()
    {
        for (int i = 0; i < numberOfCreatures.Length; i++)
        {
            if (numberOfCreatures[i].GetComponent<CreatureScript>().hasEaten == false)
            {
                Destroy(numberOfCreatures[i]);
                Unfit++;
            }
        }
        ResetEnergy(); // resetira varijablu hasEaten za svaki organizam
    }

    public void ResetEnergy()
    {
        foreach (GameObject cr in numberOfCreatures)
        {
            cr.GetComponent<CreatureScript>().hasEaten = false;
            cr.GetComponent<CreatureScript>().energy = 100;
        }
    }

    public GameObject Modify(GameObject organizam, int mutationChance, int index) // genetski modificira organizme
    {
        GameObject newOrganizam = organizam;

        if (mutationChance == 10 && numberOfCreatures[index].GetComponent<CreatureScript>().size < 2.5f) // 5 % sansa za mutaciju velicine
        {
            newOrganizam.GetComponent<CreatureScript>().size = numberOfCreatures[index].GetComponent<CreatureScript>().size * Random.Range(0.75f, 1.35f); // veca sansa da dodje do rasta    
            if (newOrganizam.GetComponent<CreatureScript>().size > 2.5f)
            {
                newOrganizam.GetComponent<CreatureScript>().size -= 0.5f;
            }
            return newOrganizam;
        }
        else if (mutationChance == 15 && numberOfCreatures[index].GetComponent<CreatureScript>().speed < 2.5f)// 5 % sansa za mutaciju brzine
        {
            newOrganizam.GetComponent<CreatureScript>().speed = numberOfCreatures[index].GetComponent<CreatureScript>().speed * Random.Range(0.75f, 1.25f);
            return newOrganizam;
        }
        else
        {
            return organizam;
        }
    }

    public void CheckAgain()
    {
        for(int i = 0; i < numberOfCreatures.Length; i++)
        {
            if (numberOfCreatures[i].transform.position.x < wallWest.transform.position.x || numberOfCreatures[i].transform.position.y > wallNorth.transform.position.y)
            {
                numberOfCreatures[i].transform.position = new Vector2(wallWest.transform.position.x + 2f, wallSouth.transform.position.y + 1f);
            }
            else if (numberOfCreatures[i].transform.position.x > blockade.transform.position.x)
            {
                numberOfCreatures[i].transform.position = new Vector2(wallWest.transform.position.x + 2f, wallSouth.transform.position.y + 1f);
            }
        }
    }


    public void Start1X() // stavlja ubrzavanje na 1x
    {
        speedUpFactor = 1;
    }
    public void Start2X() // stavlja ubrzavanje na 2x
    {
        speedUpFactor = 2;
    }
    public void Start5X() // stavlja ubrzavanje na 5x
    {
        speedUpFactor = 5;
    }

    // SPAGETTI CODE BELLOW (KOD ZA KVIZ)
    public void GreenButton0()
    {
        if (numberOfQuestions == 2)
        {
            button0.color = Color.green;
            Invoke("ChangeColorBackToWhite", 1f);
            Invoke("WaitForAdd", 1f);
        }
    }

    public void GreenButton1()
    {
        if (numberOfQuestions == 1)
        {
            button1.color = Color.green;
            Invoke("ChangeColorBackToWhite", 1f);
            Invoke("WaitForAdd", 1f);
        }
    }
    public void GreenButton2()
    {
        if (numberOfQuestions == 3)
        {
            button2.color = Color.green;
            Invoke("ChangeColorBackToWhite", 1f);
            Invoke("WaitForAdd", 1f);
        }
    }

    public void RedButton0()
    {
        if (numberOfQuestions == 1)
        {
            WrongAnwser(0);
        }
        else if (numberOfQuestions == 3)
        {
            WrongAnwser(1);
        }
    }

    public void RedButton1()
    {
        if (numberOfQuestions == 2)
        {
            WrongAnwser(1);
        }
        else if (numberOfQuestions == 3)
        {
            WrongAnwser(1);
        }
    }

    public void RedButton2()
    {
        if (numberOfQuestions == 1)
        {
            WrongAnwser(2);
        }
        else if (numberOfQuestions == 2)
        {
            WrongAnwser(2);
        }
    }

    public void ChangeColorBackToWhite() // mjenja boju tipki nazad u bijelo i nastavlja s iducim pitanjem
    {
        button0.color = Color.white;
        button1.color = Color.white;
        button2.color = Color.white;
    }

    public void WaitForReset()
    {
        numberOfQuestions = 1;
    }

    public void WaitForAdd()
    {
        numberOfQuestions++; // krece na iduce pitanje kad je tocan odgovor pritisnut
    }

    public void WrongAnwser(int buttonNum)
    {
        if (buttonNum == 0)
        {
            button0.color = Color.red;
        }
        else if (buttonNum == 1)
        {
            button1.color = Color.red;
        }
        else
        {
            button2.color = Color.red;
        }
        Invoke("ChangeColorBackToWhite", 1f);
        Invoke("WaitForReset", 1f);
    }

    public void EndQuestionSection()
    {
        objectOnScreen0.SetActive(false);
        objectOnScreen2.SetActive(true);
    }
}
