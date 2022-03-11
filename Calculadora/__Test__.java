import java.io.*;
import org.antlr.runtime.*;
import org.antlr.runtime.debug.DebugEventSocketProxy;


public class __Test__ {

    public static void main(String args[]) throws Exception {
        Gramatica_CalculadoraLexer lex = new Gramatica_CalculadoraLexer(new ANTLRFileStream("C:\\Users\\Usuario\\Google Drive\\UASLP\\Semestre X\\Fundamentos de Software de Sistemas\\Laboratorio\\SICXE\\Calculadora\\Calculadora\\__Test___input.txt", "UTF8"));
        CommonTokenStream tokens = new CommonTokenStream(lex);

        Gramatica_CalculadoraParser g = new Gramatica_CalculadoraParser(tokens, 49100, null);
        try {
            g.programa();
        } catch (RecognitionException e) {
            e.printStackTrace();
        }
    }
}