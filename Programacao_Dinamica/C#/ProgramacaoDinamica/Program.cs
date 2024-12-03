namespace ProgramacaoDinamica;

class Program
{
    public static void ImprimeArray(List<int> lista)
    {
        foreach (var item in lista)
        {
            Console.WriteLine($"Comprimento: {item}");
        }
    }
    public static (int,List<int>) CorteHastes(int[] precos, int tamanho)
    {
        int[] agregados = new int[tamanho+1];
        int[] indexes = new int[tamanho+1];
        List<int> comprimentos = new List<int>();
        for (int i = 1; i < agregados.Length; i++)
        {
            int max = Int32.MinValue;
            for (int j = 1; j <= i; j++)
            {
                if (max < precos[j-1] + agregados[i-j])
                {
                    max = precos[j-1] + agregados[i-j];
                    indexes[i] = j;
                }
            }
            agregados[i] = max;
        }
        int size = indexes[indexes.Length-1];
        comprimentos.Add(size);
        while (size < tamanho)
        {
            comprimentos.Add(tamanho-size);
            size += tamanho-size;
        }
        return (agregados[agregados.Length-1], comprimentos);
    }
    public static void Main(string[] args)
    {
        int[] precos = { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
        (int total, List<int> items) = CorteHastes(precos, 7);
        Console.WriteLine($"Total agregado: {total}");
        ImprimeArray(items);
    }
}