public class GameInformation
{
    /*
     * 
     * Environment Deck Information
     * 
     * **/
    public enum ENVIRONMENT_CARD_TYPES { SNOWFALLEVEN, SNOWFALLODD, SNOWFALLALL, WHITEOUT, WARMDAY, COLDSNAP }
    /*
     * SNOWFALLEVEN: SNOWFALL on even numbered tiles
     * SNOWFALLODD: SNOWFALL on odd numbered tiles
     * SNOWFALLALL: SNOWFALL on all tiles
     * WHITEOUT: Confusion, rotate rings
     * WARMDAY: Melt 1 snow on all tiles
     * COLDSNAP: +1 Frostbite
     * **/
    public  static int NUM_SNOWFALLEVEN = 4;
    public static int NUM_SNOWFALLODD = 4;
    public static int NUM_SNOWFALLALL = 2;
    public static int NUM_WHITEOUT = 3;
    public static int NUM_WARMDAY = 3;
    public static int NUM_COLDSNAP = 4;


    public static ENVIRONMENT_CARD_TYPES[] UNSHUFFLED_DECK = new ENVIRONMENT_CARD_TYPES[]
    {
        ENVIRONMENT_CARD_TYPES.SNOWFALLEVEN, ENVIRONMENT_CARD_TYPES.SNOWFALLEVEN,
        ENVIRONMENT_CARD_TYPES.SNOWFALLEVEN, ENVIRONMENT_CARD_TYPES.SNOWFALLEVEN,
        ENVIRONMENT_CARD_TYPES.SNOWFALLODD, ENVIRONMENT_CARD_TYPES.SNOWFALLODD,
        ENVIRONMENT_CARD_TYPES.SNOWFALLODD, ENVIRONMENT_CARD_TYPES.SNOWFALLODD,
        ENVIRONMENT_CARD_TYPES.SNOWFALLALL, ENVIRONMENT_CARD_TYPES.SNOWFALLALL,
        ENVIRONMENT_CARD_TYPES.WHITEOUT, ENVIRONMENT_CARD_TYPES.WHITEOUT,
        ENVIRONMENT_CARD_TYPES.WHITEOUT, ENVIRONMENT_CARD_TYPES.WARMDAY,
        ENVIRONMENT_CARD_TYPES.WARMDAY, ENVIRONMENT_CARD_TYPES.WARMDAY,
        ENVIRONMENT_CARD_TYPES.COLDSNAP, ENVIRONMENT_CARD_TYPES.COLDSNAP,
        ENVIRONMENT_CARD_TYPES.COLDSNAP, ENVIRONMENT_CARD_TYPES.COLDSNAP
    };


    /*
     * 
     * Adventurer Information
     * basic information that represents an adventurer 
     *
     * **/
    public enum ADVENTURERS { SNOWPATROL, COOK, ENGINEER, SKIER, MOUNTAINEER, DOGSLED }

    public static int TOTALHEALTH_SNOWPATROL = 5;
    public static int TOTALCARRY_SNOWPATROL = 2;

    public static int TOTALHEALTH_COOK = 5;
    public static int TOTALCARRY_COOK = 1;

    public static int TOTALHEALTH_ENGINEER = 3;
    public static int TOTALCARRY_ENGINEER = 2;

    public static int TOTALHEALTH_SKIER = 3;
    public static int TOTALCARRY_SKIER = 2;

    public static int TOTALHEALTH_MOUNTAINEER = 4;
    public static int TOTALCARRY_MOUNTAINEER = 2;

    public static int TOTALHEALTH_DOGSLED = 3;
    public static int TOTALCARRY_DOGSLED = 5;





}
