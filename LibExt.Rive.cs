
# region Heading

/**************************************************************************************************************/
/*                                                                                                            */
/*  LibExt.Rive.cs                                                                                            */
/*                                                                                                            */
/*  Split a string, with the ability to honor quotes and escapes                                              */
/*                                                                                                            */
/*  This is free code, use it as you require. If you modify it please use your own namespace.                 */
/*                                                                                                            */
/*  If you like it or have suggestions for improvements please let me know at: PIEBALDconsult@aol.com         */
/*                                                                                                            */
/*  Modification history:                                                                                     */
/*  2010-03-23          Sir John E. Boucher     Created                                                       */
/*                                                                                                            */
/**************************************************************************************************************/

# endregion

namespace PIEBALD.Lib.LibExt.Rive
{
    /**
    <summary>
        Options for use with Rive.
    </summary>
    */
    [System.FlagsAttribute()]
    public enum Option
    {
        /**
        <summary>
            No options.
        </summary>
        */
        None = 0 
    ,
        /**
        <summary>
            Do not include empty substrings.
        </summary>
        */
        RemoveEmptyEntries = 1
    ,
        /**
        <summary>
            Treat a special character following a backslash (\) as a regular character.
        </summary>
        */
        HonorEscapes = 2
    ,
        /**
        <summary>
            Do not split on delimiters within quotes (").
        </summary>
        */
        HonorQuotes = 4
    ,
        /**
        <summary>
            Do not split on delimiters within apostrophes (').
        </summary>
        */
        HonorApostrophes = 8
    }
    
    public static partial class LibExt
    {
        private static readonly char[] defaultdelimiters ;
            
        static LibExt
        (
        )
        {
            /* According to MSDN, these are the default delimiters for Split */
            defaultdelimiters = new char[] 
            { 
                '\u0009' , '\u000A' , '\u000B' , '\u000C' , '\u000D' , 
                '\u0020' , '\u0085' , '\u00A0' , '\u1680' , '\u2000' ,
                '\u2001' , '\u2002' , '\u2003' , '\u2004' , '\u2005' ,
                '\u2006' , '\u2007' , '\u2008' , '\u2009' , '\u200A' ,
                '\u2028' , '\u2029' , '\u3000'
            } ;
            
            return ;
        }
            
        /**
        <summary>
            Split a string, with the ability to honor quotes and escapes.
        </summary>
        <remarks>
            See the MSDN documentation for 
            System.String.Split ( Char[] , Int32 , StringSplitOptions )
        </remarks>
        <param name="Subject">
            The string to split.
        </param>
        <param name="Delimiters">
            A collection of characters to use as delimiters.
        </param>
        <returns>
            A read-only List of substrings.
        </returns>
        <exception cref="System.ArgumentNullException">
            If the Subject is null.
        </exception>
        */
        public static System.Collections.Generic.IList<string>
        Rive
        (
            this string   Subject
        ,
            params char[] Delimiters
        )
        {
            if ( Subject == null )
            {
                throw ( new System.ArgumentNullException 
                    ( "Subject" , "Subject must not be null" ) ) ;
            }
            
            return ( DoRive ( Subject , System.Int32.MaxValue , Option.None , Delimiters ) ) ;
        }

        /**
        <summary>
            Split a string, with the ability to honor quotes and escapes.
        </summary>
        <remarks>
            See the MSDN documentation for 
            System.String.Split ( Char[] , Int32 , StringSplitOptions )
        </remarks>
        <param name="Subject">
            The string to split.
        </param>
        <param name="Count">
            The maximum number of substrings to return.
        </param>
        <param name="Delimiters">
            A collection of characters to use as delimiters.
        </param>
        <returns>
            A read-only List of substrings.
        </returns>
        <exception cref="System.ArgumentNullException">
            If the Subject is null.
        </exception>
        <exception cref="System.ArgumentOutOfRangeException">
            If the Count is negative.
        </exception>
        */
        public static System.Collections.Generic.IList<string>
        Rive
        (
            this string   Subject
        ,
            int           Count
        ,
            params char[] Delimiters
        )
        {
            if ( Subject == null )
            {
                throw ( new System.ArgumentNullException 
                    ( "Subject" , "Subject must not be null" ) ) ;
            }
            
            if ( Count < 0 )
            {
                throw ( new System.ArgumentOutOfRangeException 
                    ( "Count" , "Count must not be negative" ) ) ;
            }
            
            return ( DoRive ( Subject , Count , Option.None , Delimiters ) ) ;
        }

        /**
        <summary>
            Split a string, with the ability to honor quotes and escapes.
        </summary>
        <remarks>
            See the MSDN documentation for 
            System.String.Split ( Char[] , Int32 , StringSplitOptions )
        </remarks>
        <param name="Subject">
            The string to split.
        </param>
        <param name="Options">
            Options to apply during the split process.
        </param>
        <param name="Delimiters">
            A collection of characters to use as delimiters.
        </param>
        <returns>
            A read-only List of substrings.
        </returns>
        <exception cref="System.ArgumentNullException">
            If the Subject is null.
        </exception>
        */
        public static System.Collections.Generic.IList<string>
        Rive
        (
            this string   Subject
        ,
            Option        Options
        ,
            params char[] Delimiters
        )
        {
            if ( Subject == null )
            {
                throw ( new System.ArgumentNullException 
                    ( "Subject" , "Subject must not be null" ) ) ;
            }
            
            return ( DoRive ( Subject , System.Int32.MaxValue , Options , Delimiters ) ) ;
        }

        /**
        <summary>
            Split a string, with the ability to honor quotes and escapes.
        </summary>
        <remarks>
            See the MSDN documentation for 
            System.String.Split ( Char[] , Int32 , StringSplitOptions )
        </remarks>
        <param name="Subject">
            The string to split.
        </param>
        <param name="Count">
            The maximum number of substrings to return.
        </param>
        <param name="Options">
            Options to apply during the split process.
        </param>
        <param name="Delimiters">
            A collection of characters to use as delimiters.
        </param>
        <returns>
            A read-only List of substrings.
        </returns>
        <exception cref="System.ArgumentNullException">
            If the Subject is null.
        </exception>
        <exception cref="System.ArgumentOutOfRangeException">
            If the Count is negative.
        </exception>
        */
        public static System.Collections.Generic.IList<string>
        Rive
        (
            this string   Subject
        ,
            int           Count
        ,
            Option        Options
        ,
            params char[] Delimiters
        )
        {
            if ( Subject == null )
            {
                throw ( new System.ArgumentNullException 
                    ( "Subject" , "Subject must not be null" ) ) ;
            }
            
            if ( Count < 0 )
            {
                throw ( new System.ArgumentOutOfRangeException 
                    ( "Count" , "Count must not be negative" ) ) ;
            }
            
            return ( DoRive ( Subject , Count , Options , Delimiters ) ) ;
        }

        private static System.Collections.Generic.IList<string>
        DoRive
        (
            string Subject
        ,
            int    Count
        ,
            Option Options
        ,
            char[] Delimiters
        )
        {
            System.Collections.Generic.List<string> result = 
                new System.Collections.Generic.List<string>() ;

            if ( Count > 1 )
            {
                System.Text.StringBuilder temp = 
                    new System.Text.StringBuilder() ;
                    
                System.Collections.Generic.HashSet<char> delims = 
                    new System.Collections.Generic.HashSet<char>() ;
                    
                if ( Delimiters != null )
                {
                    delims.UnionWith ( Delimiters ) ;
                }
                
                if ( delims.Count == 0 )
                {
                    delims.UnionWith ( defaultdelimiters ) ;
                }
                
                bool remove = ( Options & Option.RemoveEmptyEntries ) == Option.RemoveEmptyEntries ;
                bool escape = ( Options & Option.HonorEscapes       ) == Option.HonorEscapes       ;
                bool quote  = ( Options & Option.HonorQuotes        ) == Option.HonorQuotes        ;
                bool apos   = ( Options & Option.HonorApostrophes   ) == Option.HonorApostrophes   ;
                
                char ch  ;
                int  pos = 0 ;
                int  len = Subject.Length ;
                
                while ( pos < len )
                {
                    ch = Subject [ pos++ ] ;
                    
                    if ( delims.Contains ( ch ) )
                    {
                        if ( ( temp.Length > 0 ) || !remove )
                        {
                            result.Add ( temp.ToString() ) ;
                            
                            temp.Length = 0 ;
                            
                            if 
                            (
                                ( result.Count == Count - 1 )
                            &&
                                ( pos < len )
                            )    
                            {
                                temp.Append ( Subject.Substring ( pos ) ) ;
                                
                                pos = len ;
                            }
                        }
                    }
                    else
                    {
                        if ( escape && ( ch == '\\' ) && ( pos < len ) )
                        {
                            temp.Append ( ch ) ;

                            ch = Subject [ pos++ ] ;
                        }
                        else if ( quote && ( ch == '\"' ) && ( pos < len ) )
                        {
                            do
                            {
                                if ( escape && ( ch == '\\' ) )
                                {
                                    temp.Append ( ch ) ;

                                    ch = Subject [ pos++ ] ;
                                }
                            
                                temp.Append ( ch ) ;

                                ch = Subject [ pos++ ] ;
                            }
                            while ( ( pos < len ) && ( ch != '\"' ) ) ;
                        }
                        else if ( apos && ( ch == '\'' ) && ( pos < len ) )
                        {
                            do
                            {
                                if ( escape && ( ch == '\\' ) )
                                {
                                    temp.Append ( ch ) ;

                                    ch = Subject [ pos++ ] ;
                                }
                            
                                temp.Append ( ch ) ;

                                ch = Subject [ pos++ ] ;
                            }
                            while ( ( pos < len ) && ( ch != '\'' ) ) ;
                        }
                            
                        temp.Append ( ch ) ;
                    }
                }
                
                if ( ( temp.Length > 0 ) || !remove )
                {
                    result.Add ( temp.ToString() ) ;
                }
            }
            else if ( Count == 1 )                
            {
                result.Add ( Subject ) ;
            }
                        
            return ( result.AsReadOnly() ) ;
        }
    }
}
