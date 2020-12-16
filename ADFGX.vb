Module ADFGX
    Public Matriz(5, 5) As Char
    Public TextoPuro As String
    Public PalavraChave As String
    Sub CriarMatriz()
        Matriz(0, 0) = ""
        Matriz(1, 0) = "A"
        Matriz(2, 0) = "D"
        Matriz(3, 0) = "F"
        Matriz(4, 0) = "G"
        Matriz(5, 0) = "X"

        Matriz(0, 1) = "A"
        Matriz(1, 1) = "A"
        Matriz(2, 1) = "F"
        Matriz(3, 1) = "L"
        Matriz(4, 1) = "Q"
        Matriz(5, 1) = "V"

        Matriz(0, 2) = "D"
        Matriz(1, 2) = "B"
        Matriz(2, 2) = "G"
        Matriz(3, 2) = "M"
        Matriz(4, 2) = "R"
        Matriz(5, 2) = "W"

        Matriz(0, 3) = "F"
        Matriz(1, 3) = "C"
        Matriz(2, 3) = "H"
        Matriz(3, 3) = "N"
        Matriz(4, 3) = "S"
        Matriz(5, 3) = "X"

        Matriz(0, 4) = "G"
        Matriz(1, 4) = "D"
        Matriz(2, 4) = "I"
        Matriz(3, 4) = "O"
        Matriz(4, 4) = "T"
        Matriz(5, 4) = "Y"

        Matriz(0, 5) = "X"
        Matriz(1, 5) = "E"
        Matriz(2, 5) = "K"
        Matriz(3, 5) = "P"
        Matriz(4, 5) = "U"
        Matriz(5, 5) = "Z"
    End Sub

    Sub Main()
        CriarMatriz() 'Matriz(linha,coluna)
        Console.WriteLine("Sistema de criptografia ADFGX")
        Console.Write("Texto a ser criptografado: ")
        TextoPuro = Console.ReadLine.ToUpper
        Console.Write("Palavra-chave: ")
        PalavraChave = Console.ReadLine.ToUpper

        Console.WriteLine("Texto: {0}", TextoPuro)
        Console.WriteLine("-------------------")
        'Etapa 1
        Console.WriteLine("Etapa 1:")
        Dim pnt As Integer = 0
        Dim res As New Text.StringBuilder
        Do
            For c As Integer = 1 To 5
                For l As Integer = 1 To 5
                    If Char.IsWhiteSpace(TextoPuro(pnt)) = True Then
                        pnt += 1
                        res.Append(" ")
                    End If
                    If Matriz(l, c) = TextoPuro(pnt).ToString.ToUpper Then
                        res.Append(Matriz(l, 0) & Matriz(0, c))
                    End If
                Next
            Next
            pnt += 1
        Loop Until pnt = TextoPuro.Length - 1
        Console.WriteLine(res.ToString)
        Console.ReadKey()
        res.Replace(" ", "")
        'Etapa 2
        pnt = 0
        Dim Matriz2(PalavraChave.Length - 1, Int(res.Length / PalavraChave.Length) + 1) As Char

        For c As Integer = 0 To Matriz2.GetUpperBound(1)
            For l As Integer = 0 To Matriz2.GetUpperBound(0)
                Matriz2(l, c) = res(pnt)
                pnt += 1
                If pnt = res.Length Then Exit For
            Next
            If pnt = res.Length Then Exit For
        Next

        Console.WriteLine("Etapa 2:")
        Dim i As Integer = 1
        For c As Integer = 0 To Matriz2.GetUpperBound(1)
            For l As Integer = 0 To Matriz2.GetUpperBound(0)
                Console.Write(Matriz2(l, c))
            Next
            Console.WriteLine()
        Next

        Console.ReadKey()
        'Etapa3
        pnt = 0
        res.Clear()
        Dim Matriz3() As Char = PalavraChave
        Array.Sort(Matriz3)

        Console.WriteLine("Etapa 3:")
        Do
            Dim c As Integer
            c = PalavraChave.IndexOf(Matriz3(pnt))
            For l As Integer = 0 To Matriz2.GetUpperBound(1)
                res.Append(Matriz2(c, l))
            Next
            res.Append(" ")
            pnt += 1
        Loop Until pnt >= Matriz3.GetUpperBound(0)

        Console.WriteLine(res.ToString)
        Console.ReadKey()
    End Sub

End Module
