#lang racket
(require xml)
(require xml/xexpr)
(require xml/plist)
(require racket/gui/base)

; default xml
(define tableFile "lexTable.xml")

; the message to display for each token based on type id
(define tokenMsgs '((3 "Invalid exponit for float_lit: ")
                    (21 "Invalid exponit for float_lit: ")
                    (22 "Invalid exponit for float_lit: ")
                    (2 "Space expected for float_lit: ")
                    (4 "Invalid token: ")
                    (1 "Token can not be on its own line: ")
                    (5 "Assign: ")
                    (6 "Comma: ")
                    (7 "Comp_op: ")
                    (9 "Float_lit: ")
                    (17 "ID: ")
                    (10 "Int_lit: ")
                    (11 "Lbrace: ")
                    (12 "Lparen: ")
                    (13 "Op: ")
                    (15 "Rbrace: ")
                    (16 "Rparen: ")))

; Call to start the program
(define (startLexAnls)
  (displayReadme)
  (menu)
  )

; function to display the main menu to the user
(define (menu)
  (let ((input (string-downcase (read-line))))
    (if (not (string=? input ""))
        (cond [(string=? (substring input 0 1) "s") (getFile) (menu)] ; start scan
              [(string=? (substring input 0 1) "l") (setXml) (menu)] ; load new table
              [(string=? (substring input 0 1) "r") (set tableFile "lexTable.xml") ; reset to the default xml
                                                    (display "XML file reset to default\n") (menu)] 
              [(string=? (substring input 0 1) "h") (displayReadme) (menu)] ; display readme.txt
              [(string=? (substring input 0 1) "q") '()] ; quit
              [else (display "[ERR] Invalid command\n") (menu)] ; catch invalid commands and continue
              )
        (menu)
        )
    )
  )

; Prompt the user for a new table and verify it exsits
(define (setXml)
  (display "Enter the file path: ")
  (let ((file (read-line)))
    ; check if the file exsits before setting it
    (if (file-exists? file)
        (set tableFile file)
        (display "[ERR] Given file not found\n")
        )
    )
  )

; Open and display the readme file
(define (displayReadme)
  (display (make-string 79 #\*))
  (newline)
  (if (file-exists? "readme.txt")
      (display (readLines (open-input-file "readme.txt")))
      (display "[ERR] readme.txt was not found")
      )
  (newline)
  (display (make-string 79 #\*))
  (newline)
  )

; Prompt the user for the file
(define (getFile)
  (display "Enter the file path: ")
  (let ((file (read-line))
        (tokens '()))
    (display "Scaning: ")
    (display file)
    (set! tokens (beginScan (getTables tableFile) (readFile file)))
    (newline)
    (display (make-string 79 #\*))
    (newline)
    (display "Tokens found: ")
    (display (length tokens))
    (display "\tErrors: ")
    (display (length (getErrors tokens)))
    (newline)
    (display "Press enter to display next token\n")
    (display "Enter e or error to view error\n")
    (display "Enter q or quit to stop\n")
    (displayTokens tokens (getErrors tokens))
    (display (make-string 30 #\*))
    (display "end of token stream")
    (display (make-string 30 #\*))
    (newline)
    )
  )

; display the tokens
(define (displayTokens tokenList errorList)
  (let ((char (read-char)))
    (cond [(and (eq? char #\newline) (pair? tokenList)) ; get and display next token
           (display (createMsg (car tokenList)))
           (displayTokens (cdr tokenList) errorList)] ; end of stream
          [(eq? char #\newline)
           '()]
          [(or (eq? char #\e) (eq? char #\E)) ; display found errors
           (display (make-string 37 #\*))
           (display "Error")
           (display (make-string 37 #\*))
           (newline)
           (if (eq? (length errorList) 0)
               (display "No Errors Found\n")
               (displayAll errorList))
           (display (make-string 79 #\*))
           (newline)
           (eatNewlines)
           (displayTokens tokenList errorList)]
          [(or (eq? char #\q) (eq? char #\Q)) ; quit the scan
           '()]
          [else (displayTokens tokenList errorList)])
    )
  )

; Displays the entire list without awaiting input for next token
(define (displayAll tokenList)
  (cond [(pair? tokenList) 
         (display (createMsg (car tokenList))) (newline)
         (displayAll (cdr tokenList))]
        [else '()]
        )
  )

; creats the msg to display
(define (createMsg token)
  (if (assoc (car token) tokenMsgs)
      (string-append (cadr (assoc (car token) tokenMsgs)) (cdr token) "\n")
      (string-append "Keyword: " (cdr token) "\n")
      )
  )

; Eats chars up to a newline
(define (eatNewlines)
  (if(eq? (read-char) #\newline)
     '()
     (eatNewlines)
     )
  )

; Open a file and read in its contents returning a list of the characters in the file
(define (readFile file)
  (if (file-exists? file)
      (string->list (readLines (open-input-file file)))
      'error
      )
  )

; Recursivly reads all lines in the file and return a string 
(define (readLines file)
  (define line (read-line file))
  (if (eof-object? line)
      ""
      (string-append (string-downcase line) (readLines file))
      )
  )

; clears non lists from a list used for removing \n\r from the xml file
(define (removeNonLists xml)
  (filter list? xml)
  )

; Get the lex and lookup table from the xml
(define (getTables xmlFile)
  (xexpr-drop-empty-attributes #t)
  (if (file-exists? xmlFile)
      (cddddr (cdr (removeNonLists (xml->xexpr (document-element(read-xml (open-input-file xmlFile)))))))
      '()
      )
  )

; gets the LexTable from the tables loaded from the xml
(define (getLexTable tables)
  (remove-firstColumn (clean-rows (cddr (cdddar (cdddar tables)))))
  )

; gets the table for keywords lookup from the tables loaded from the xml
(define (getLookupTable tables)
  (clean-rows (cdr (removeNonLists (cddadr (cddadr tables)))))
  )

; cleans the rows by removing \n\r and other nonLists
(define (clean-rows table)
  (if (pair? table)
      (cons (removeNonLists (cddar table)) (clean-rows (removeNonLists (cdr table))))
      '()
      )
  )

; remove the first column from the table since it is for readablity only
(define (remove-firstColumn table)
  (if (pair? table)
      (cons (cdar table) (remove-firstColumn (cdr table)))
      '()
      )
  )

; build the lookup table
(define (buildLookupTable table)
  (if (pair? table)
      (cons (getData (car table)) (buildLookupTable (cdr table)))
      '()
      )
  )

; get the values in the data tags and return it in a (c1 c2) form
(define (getData row)
  (cons (getRightCell row) (string->number (getLeftCell row)))
  )

; get left cell
(define (getLeftCell row) (car (cddadr (car row))))

; get right cell
(define (getRightCell row) (car (cddadr (cadr row))))

; build the lex table
(define (buildLexTable tables)
  (let ((header (getHeader (car (getLexTable tables)))))
    header
    )
  )

; take a row and create a list of states
(define (getStateList row)
  (if (pair? row)
      (let ((strState (last (assoc 'Data (cdar row))))
            (state -1))
        (cond ([string=? strState "-"] '())
              [else (set! state (string->number strState))]
              )
        (cons state (getStateList (cdr row)))
        )
      '()
      )
  )

; build the dfa
(define (buildDFA state header transTable)
  (if (pair? transTable)
      (append (createStateDFA state header (getStateList (car transTable))) (buildDFA (+ state 1) header (cdr transTable)))
      '()
      )
  )

; get the transition table
(define (createStateDFA state header stateList)
  (if (pair? header)
      (cons (cons (cons state (car header)) (car stateList)) (createStateDFA state (cdr header) (cdr stateList)))
      '()
      )
  )

; get the header of the table
(define (getHeader table) 
  (if (pair? table)
      (cons (toChar (caddr (assoc 'Data (cdar table)))) (getHeader (cdr table)))
      '()
      )
  )

; convert the passed string from the header to a char with some 
(define (toChar string)
  (cond [(string=? string "Space") #\space]
        [(string=? string "Tab") #\tab]
        [(string=? string "NewLine") #\return]
        [else (car (string->list string))])
  )

; the entry function to get the list of tokens in the given file
(define (getTokens dfa keyWordTable srcCode)
  (cleanList (scan 0 dfa srcCode '()) keyWordTable)
  )

; takes a token list and returns a list of error tokens stored in it
(define (getErrors tokenList)
  (if (pair? tokenList)
      (cond [(or (eq? (caar tokenList) 1) (or (eq? (caar tokenList) 2) ; check if the token is an error token
                                              (or (eq? (caar tokenList) 3) (eq? (caar tokenList) 4))))
             (append (list (car tokenList)) (getErrors (cdr tokenList)))] ; append the error token to the list
            [else (getErrors (cdr tokenList))]) ; if not an error token move on
      '()) ; end of the list
  )

; scan the src code for tokens and return them
(define (scan state dfa srcCode symbol)
  (if(pair? srcCode)
     (if (eq? -1 (cdr (assoc (cons state (car srcCode)) dfa)))
         (append (list (cons state (list->string symbol))) (scan 0 dfa srcCode '()))
         (scan (cdr (assoc (cons state (car srcCode)) dfa)) dfa (cdr srcCode)  (append symbol (removeWhiteSpace (car srcCode))))
         )
     (list (cons state (list->string symbol)))
     )
  )

; remove white space 
(define (removeWhiteSpace char)
  (cond [(char=? char #\space) '()]
        [(char=? char #\tab) '()]
        [(char=? char #\return) '()]
        [else (list char)])
  )

; clean up the token list by removing and condencing tokens
(define (cleanList tokenList keyWordTable)
  (if (pair? tokenList)
      ; check if it is an id a token that can be condenced or an unecessarry token
      (append (cond [(or (eq? (caar tokenList) 18) (or (eq? (caar tokenList) 23) (or (eq? (caar tokenList) 24) (eq? (caar tokenList) 25)))) '()] ; Comment
                    [(eq? (caar tokenList) 20) '()] ; newline error check
                    [(eq? (caar tokenList) 8) (list (cons 7 (cdar tokenList)))] ; Less than greater than check
                    [(eq? (caar tokenList) 14) (list (cons 13 (cdar tokenList)))] ; division operation check
                    [(eq? (caar tokenList) 17) (list (keyWordLookup (car tokenList) keyWordTable))] ; ID
                    [else (list (car tokenList))])
              (cleanList (cdr tokenList) keyWordTable))
      '()
      )
  )

; Look up if the id is a keyword
(define (keyWordLookup token keyWordTable)
  (if (assoc (cdr token) keyWordTable)
      (cons (cdr (assoc (cdr token) keyWordTable)) (car (assoc (cdr token) keyWordTable)))
      token
      )
  )

; A function to prep the passed tables for scaning and then scans the provided file for tokens
(define (beginScan tables srcCode)
  (getTokens (buildDFA '0 (getHeader (car (getLexTable tables))) (cdr (getLexTable tables))) (buildLookupTable (getLookupTable tables)) srcCode)
  )

(startLexAnls)