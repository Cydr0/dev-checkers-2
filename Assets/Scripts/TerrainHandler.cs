using UnityEngine;

public class TerrainHandler : MonoBehaviour
{

    public HexCell cellPrefab;

    HexCell[] cells;

    public int size = 5;

    float hexWidth = 1.73f;
    float hexHeight = 2f;
    public float gap = 0.1f;

    Vector2 startPos;

    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        int length = 0;
        for(int i = 0; i < size; i++)
        {
            length += getOffset(i);
        }
        cells = new HexCell[length];

        AddGap();
        CalcStartPos();
        CreateGrid();
    }

    void CalcStartPos()
    {
        float x = (size * hexWidth) / 4.0f;
        float y = (size * hexHeight) / 4.0f;
        startPos = new Vector2(-x,-y);
    }

    void AddGap()
    {
        hexWidth += gap;
        hexHeight += gap;
    }

    Vector3 CalcWorldPos(Vector2 gridPos)
    {
        float offset = getOffset((int)gridPos.y);
        offset -= offset/2.0f;
        




        float x = startPos.x+((gridPos.x-offset) * hexWidth);
        float z = startPos.y+(gridPos.y * hexHeight*0.75f);

        float scale = 0.1f;

        float y = Mathf.PerlinNoise(x*scale, z*scale);


        return new Vector3(x, 0, z); // Change 0 to perlin noise value;
    }

    void CreateGrid()
    {

        int seed = Random.Range(0, 10000);

        float scale = 0.5f;
        int i = 0;
        for (int y = 0; y < size; y ++){
            for (int x = 0; x < getOffset(y); x++){

                HexCell hex = Instantiate(cellPrefab);
                Vector2 gPos = new Vector2(x,y);
                Vector3 worldPos = CalcWorldPos(gPos);
                float pX = (worldPos.x / hexWidth) * scale + seed;
                float pZ = (worldPos.z / hexHeight) * scale + seed;
                float height = Mathf.PerlinNoise(pX, pZ);
                int terrainType = 0;
                if(height < 0.3){
                    terrainType = 0;
                }else if(height < 0.6)
                {
                    terrainType = 1;
                }
                else
                {
                    terrainType = 2;
                }

                hex.transform.position = worldPos;
                hex.transform.rotation = new Quaternion(0, Mathf.PI / 4.0f, 0, 0);
                hex.transform.parent = this.transform;
                hex.name = "Hexagon " + x +","+y+": "+i;
                hex.position = gPos;

                hex.setType(materials[terrainType]);

                cells[i] = hex;
                i++;
            }

        }
    }

    int getOffset(int y){
        return size - Mathf.Abs(y - size / 2);
    }

    int[] getNeighbours(int i)
    {
        int x = (int) cells[i].position.x;
        int y = (int) cells[i].position.y;

        int rad = (int) Mathf.Ceil(size / 2);

        int upperOffset = 0;
        int lowerOffset = 0;

        if(y < rad){
            upperOffset = 0;
            lowerOffset = -1;
        }else if(y == rad){
            upperOffset = -1;
            lowerOffset = -1;
        }else{
            upperOffset = -1;
            lowerOffset = 0;
        }

        int length = 6;
        int[] neighbours = new int[length];

        neighbours[0] = getCellIndex(x + lowerOffset, y - 1);
        neighbours[1] = getCellIndex(x + lowerOffset + 1, y - 1);

        neighbours[2] = getCellIndex(x - 1, y);
        neighbours[3] = getCellIndex(x + 1, y);

        neighbours[4] = getCellIndex(x + upperOffset, y + 1);
        neighbours[5] = getCellIndex(x + upperOffset + 1, y + 1);

        return neighbours;
    }

    int getCellIndex(int x, int y){
        for(int i = 0; i < cells.Length; i++)
        {
            if((int) cells[i].position.x == x && (int) cells[i].position.y == y)
            {
                return i;
            }
        }
        return -1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
