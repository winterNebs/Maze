'Isaac Wen 6/1/2016 "Maze game"
'Randomly generates maze for player to solve
'Control red, reach green
Public Class Form1
    'Declaring stuff
    'No naming convension due to efficiency
    ''' NOTE: there are X AND Y variables for future expandability if i so choose to. 
    Dim moves As Integer
    Dim wins As Integer = 0
    Dim FarthestBackTrack As Integer = 0
    Dim optimalMoves As Integer
    Public gridSize As New Point(31, 31)
    Dim counter As Integer = 0

    Dim arrayBackTrack As New ArrayList
    Public arrayHeight As Integer = 9
    Public arrayWidth As Integer = 9
    Dim arrayFeild((arrayWidth - 1), (arrayHeight - 1)) As block
    Dim lblWins As New Label
    Dim WithEvents btnAdvanced As New Label
    Dim WithEvents btnNew As New Label
    Dim WithEvents btnHelp As New Label
    Dim lblMoves As New Label
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Starts a new round when form loads
        NewRound()
        Buttons_Clicked(btnHelp, e)
    End Sub
    Public Sub NewRound()
        'resets variables to 0
        moves = 0
        FarthestBackTrack = 0
        'Adjusts the window size to the size of the maze
        Me.Size = New Point((gridSize.X * arrayWidth) + 15, (gridSize.Y * arrayHeight) + 60)
        'clears backtrack array used in maze generation
        arrayBackTrack.Clear()
        'Redeclares the playing feild array to that of the arraywidth x arrayheight
        ReDim arrayFeild((arrayWidth - 1), (arrayHeight - 1))
        'Clears form (pictureboxes, labels, etc.)
        Controls.Clear()
        'Generates maze (including end)
        Maze_Generator()
        'Creates a local variable for the scale of the x&y 
        Dim scaleX As Decimal = (gridSize.X - 1) / 20
        Dim scaleY As Decimal = (gridSize.Y - 1) / 20
        'Setting up all the gui stuff (like text, size, location, adding to form)
        btnNew.Text = "New Round"
        btnNew.Size = New Point(CInt(scaleX * 75), CInt(scaleY * 23))
        btnNew.Location = New Point(0, arrayFeild(0, arrayHeight - 1).Location.Y + gridSize.Y)
        btnNew.BackColor = Color.GhostWhite
        btnNew.Font = New Font("Microsoft Sans Serif", CInt(Math.Sqrt(scaleX * scaleY) * 8), FontStyle.Bold)
        Controls.Add(btnNew)
        lblWins.Text = "Wins: " & wins
        lblWins.Size = New Point(CInt(scaleX * 55), CInt(scaleY * 23))
        lblWins.Location = New Point(btnNew.Size.Width, arrayFeild(0, arrayHeight - 1).Location.Y + gridSize.Y)
        lblWins.BackColor = Color.GhostWhite
        lblWins.Font = New Font("Microsoft Sans Serif", CInt(Math.Sqrt(scaleX * scaleY) * 8), FontStyle.Bold)
        Controls.Add(lblWins)
        lblMoves.Text = "Moves: " & moves & "/" & optimalMoves
        lblMoves.Size = New Point((CInt(scaleX * 100)), CInt(scaleY * 23))
        lblMoves.Location = New Point(btnNew.Size.Width + lblWins.Size.Width, arrayFeild(0, arrayHeight - 1).Location.Y + gridSize.Y)
        lblMoves.BackColor = Color.GhostWhite
        lblMoves.Font = New Font("Microsoft Sans Serif", CInt(Math.Sqrt(scaleX * scaleY) * 8), FontStyle.Bold)
        Controls.Add(lblMoves)
        btnAdvanced.Text = "Advanced Options"
        btnAdvanced.Size = New Point((CInt(scaleX * 110)), CInt(scaleY * 23))
        btnAdvanced.Location = New Point(btnNew.Size.Width + lblWins.Size.Width + lblMoves.Size.Width, arrayFeild(0, arrayHeight - 1).Location.Y + gridSize.Y)
        btnAdvanced.BackColor = Color.GhostWhite
        btnAdvanced.Font = New Font("Microsoft Sans Serif", CInt(Math.Sqrt(scaleX * scaleY) * 8), FontStyle.Bold)
        Controls.Add(btnAdvanced)
        btnHelp.Text = "Help"
        btnHelp.Size = New Point((CInt(scaleX * 40)), CInt(scaleY * 23))
        btnHelp.Location = New Point(btnNew.Size.Width + lblWins.Size.Width + lblMoves.Size.Width + btnAdvanced.Size.Width, arrayFeild(0, arrayHeight - 1).Location.Y + gridSize.Y)
        btnHelp.BackColor = Color.GhostWhite
        btnHelp.Font = New Font("Microsoft Sans Serif", CInt(Math.Sqrt(scaleX * scaleY) * 8), FontStyle.Bold)
        Controls.Add(btnHelp)
        'Adjusts the gui stuff
        GUI_Fix()
    End Sub
    Private Sub GUI_Fix()
        'gui algorithm is annoying
        'Basically moves the last 2 elements of the gui down a row if its too long
        If lblMoves.Location.X + lblMoves.Size.Width + btnAdvanced.Size.Width > Me.Size.Width Then
            btnAdvanced.Location = New Point(0, btnNew.Location.Y + btnNew.Size.Height)
            btnHelp.Location = New Point(btnAdvanced.Location.X + btnAdvanced.Size.Width, btnNew.Location.Y + btnNew.Size.Height)
            If btnNew.Size.Width + lblWins.Size.Width + lblMoves.Size.Width > Me.Size.Width Then
                Me.Size = New Point(btnNew.Size.Width + lblWins.Size.Width + lblMoves.Size.Width, Me.Size.Height + btnAdvanced.Size.Height)
            Else
                Me.Size = New Point(Me.Size.Width, Me.Size.Height + btnAdvanced.Size.Height)
            End If
        End If
    End Sub
    Private Sub Buttons_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click, btnAdvanced.Click, btnHelp.Click
        'Checks which button(label) is pressed and does the appropriate thing
        Dim btnSender As Label = sender
        Select Case btnSender.Text
            Case Is = "New Round"
                NewRound()
            Case Is = "Larger Grid"
                arrayWidth += 2
                arrayHeight += 2
                lblMoves.Text = arrayWidth.ToString & " x " & arrayHeight.ToString
            Case Is = "Advanced Options"
                Form2.Show()
            Case Is = "Help"
                MessageBox.Show("Maze Game (May 2016) by Isaac" & vbNewLine &
                                "Objective: You, the player (red square), must reach the exit (green square). Black squares are walls, blank squares are the path you must take." & vbNewLine &
                                "Controls: Use the arrow keys to move" & vbNewLine &
                                "Advanced Options: Change the size of the playing feild and square size, more to come." & vbNewLine &
                                "Hotkeys: (N)ew Round, (A)dvanced Options, (H)elp")
        End Select
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'Handles player movement and "hotkeys"
        Dim bHandled As Boolean = False
        If bHandled = False Then
            Select Case e.KeyCode
                Case Is = Keys.Right
                    Player_Move(1)
                    e.Handled = True
                Case Is = Keys.Left
                    Player_Move(3)
                    e.Handled = True
                Case Is = Keys.Up
                    Player_Move(0)
                    e.Handled = True
                Case Is = Keys.Down
                    Player_Move(2)
                    e.Handled = True
                Case Is = Keys.N
                    Buttons_Clicked(btnNew, e)
                    e.Handled = True
                Case Is = Keys.A
                    Buttons_Clicked(btnAdvanced, e)
                    e.Handled = True
                Case Is = Keys.H
                    Buttons_Clicked(btnHelp, e)
                    e.Handled = True
            End Select
        End If
    End Sub
    Private Sub Form1_Mouse_Over(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.MouseEnter, btnAdvanced.MouseEnter, btnHelp.MouseEnter
        'Makes the label button you hover over darker so you know that you are hovering over.
        Dim btnSender As Label = sender
        btnSender.BackColor = Color.Gray
    End Sub
    Private Sub Form1_Mouse_Exit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.MouseLeave, btnAdvanced.MouseLeave, btnHelp.MouseLeave
        'Makes the label button you hover over not darker so you know that you aren't hovering over.
        Dim btnSender As Label = sender
        btnSender.BackColor = Color.GhostWhite
    End Sub
    Private Sub moved()
        moves += 1
        lblMoves.Text = "Moves: " & moves & "/" & optimalMoves
    End Sub
    Private Sub Player_Move(ByVal direction As Integer)
        'Takes a number which corrasponds with a direction 1(up),2(right),3(down),4(left)
        'Moves player accordingly
        'For loop to go through every block in the playfield
        For i = 0 To arrayHeight - 1
            For j = 0 To arrayWidth - 1
                'Finds the player block
                If arrayFeild(i, j).m_Type = 2 Then
                    'Now does the direction stuff
                    Select Case direction
                        Case Is = 0
                            'Makes sure the player isn't trying to move off screen
                            If j > 0 Then
                                'Checks that the block that the player is moving to is empty(0) the end(3) or already traveled on(4)
                                If arrayFeild(i, j - 1).m_Type = 0 Or arrayFeild(i, j - 1).m_Type = 3 Or arrayFeild(i, j - 1).m_Type = 4 Then
                                    'Makes the block that the player is on "Traveled on"
                                    arrayFeild(i, j).type(4)
                                    'If the block is the end, moves the player and ends the game, if not, just moves the player
                                    If End_Check(arrayFeild(i, j - 1)) Then
                                        arrayFeild(i, j - 1).type(2)
                                        NewRound()
                                    Else
                                        arrayFeild(i, j - 1).type(2)
                                    End If
                                    'adds one to the movement counter
                                    moved()
                                End If
                            End If
                        Case Is = 1
                            'Same thing as above but for different direction
                            If i < arrayHeight - 1 Then
                                If arrayFeild(i + 1, j).m_Type = 0 Or arrayFeild(i + 1, j).m_Type = 3 Or arrayFeild(i + 1, j).m_Type = 4 Then
                                    arrayFeild(i, j).type(4)
                                    If End_Check(arrayFeild(i + 1, j)) Then
                                        arrayFeild(i + 1, j).type(2)
                                        NewRound()
                                    Else
                                        arrayFeild(i + 1, j).type(2)
                                    End If
                                    moved()
                                End If
                            End If
                        Case Is = 2
                            'Same thing again
                            If j < arrayWidth Then
                                If arrayFeild(i, j + 1).m_Type = 0 Or arrayFeild(i, j + 1).m_Type = 3 Or arrayFeild(i, j + 1).m_Type = 4 Then
                                    arrayFeild(i, j).type(4)
                                    If End_Check(arrayFeild(i, j + 1)) Then
                                        arrayFeild(i, j + 1).type(2)
                                        NewRound()
                                    Else
                                        arrayFeild(i, j + 1).type(2)
                                    End If
                                    moved()
                                End If
                            End If
                        Case Is = 3
                            'Blah blah blah
                            If i > 0 Then
                                If arrayFeild(i - 1, j).m_Type = 0 Or arrayFeild(i - 1, j).m_Type = 3 Or arrayFeild(i - 1, j).m_Type = 4 Then
                                    arrayFeild(i, j).type(4)
                                    If End_Check(arrayFeild(i - 1, j)) Then
                                        arrayFeild(i - 1, j).type(2)
                                        NewRound()
                                    Else
                                        arrayFeild(i - 1, j).type(2)
                                    End If
                                    moved()
                                End If
                            End If
                    End Select
                    'Helps with efficency by basically exiting the for loop once it finds the player
                    '(it would be more efficent to keep track of the player's location, but this way is safer and less likely to break)
                    GoTo ENDFOR
                End If
            Next j
        Next i
ENDFOR:
    End Sub
    Private Function End_Check(ByVal EndBlock As block)
        'Checks whether the block provided is the end.
        If EndBlock.m_Type = 3 Then
            wins += 1
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Maze_Generator()
        'Randomizes stuff
        Randomize()
        'Creates a new random object
        Dim myradom As Random = New Random()
        'Randomly finds the start on a odd block (like 1,1 or 5,3)
        Dim start As New Point((CInt(myradom.Next(1, ((arrayWidth - 1) / 2))) * 2) - 1, (CInt(myradom.Next(1, ((arrayHeight - 1) / 2))) * 2) - 1)
        'Fills the array with "wall" blocks and adds them to the form
        For i = 0 To arrayHeight - 1
            For j = 0 To arrayWidth - 1
                arrayFeild(i, j) = New block(1, gridSize, New Point((i) * gridSize.X, (j) * gridSize.Y), New Point(i, j))
                Controls.Add(arrayFeild(i, j))
            Next j
        Next i
        'Adds the start to the backtrack stack
        arrayBackTrack.Add(arrayFeild(start.X, start.Y))
        'Calls the recursive method that actually generates the maze (o boy)
        'Its declared as lol just incase something bad happens when it returns -1
        Dim lol As Integer = Recursive_Maze(arrayFeild(start.X, start.Y))
        'Makes the start the player
        arrayFeild(start.X, start.Y).type(2)
        'Sets the distance from the player to the player to 0
        arrayFeild(start.X, start.Y).m_Dist = 0
        'Calls the recursive method with (distance = 0) that genrates the end (o boy) and sets the distance to the optimal moves
        optimalMoves = Recursive_End(0)
        'Searches the all the blocks and sees which is the farthest from the player 
        'Sets the farthest block to the end
        For i = 0 To arrayHeight - 1
            For j = 0 To arrayWidth - 1
                If arrayFeild(i, j).m_Dist = optimalMoves Then
                    arrayFeild(i, j).type(3)
                    'Makes sure that there can only be one!
                    GoTo END_END_GENERATION
                End If
            Next j
        Next i
END_END_GENERATION:
    End Sub
    Private Function Recursive_End(ByVal count As Integer)
        ''Basically marks the distance of the surrounding spaces and then repeats with the newly marked spaces
        Dim counted As Boolean = False
        'Checks all blocks in the maze (so not the outer walls)
        For i = 1 To arrayHeight - 2
            For j = 1 To arrayWidth - 2
                'if the block is has the same distance as the "count" (for the first time it would be equal to 0, which is the player/start)
                If arrayFeild(i, j).m_Dist = count Then
                    'If the block in each direction is unchecked (-1) and it is not a wall, then make its distance, the current distance + 1.
                    'Set counted to true after doing that any number of times above 0, so that we know whether we have reached the end or not. 
                    If arrayFeild(i + 1, j).m_Dist = -1 And arrayFeild(i + 1, j).m_Type = 0 Then
                        arrayFeild(i + 1, j).m_Dist = count + 1
                        counted = True
                    End If
                    If arrayFeild(i - 1, j).m_Dist = -1 And arrayFeild(i - 1, j).m_Type = 0 Then
                        arrayFeild(i - 1, j).m_Dist = count + 1
                        counted = True
                    End If
                    If arrayFeild(i, j + 1).m_Dist = -1 And arrayFeild(i, j + 1).m_Type = 0 Then
                        arrayFeild(i, j + 1).m_Dist = count + 1
                        counted = True
                    End If
                    If arrayFeild(i, j - 1).m_Dist = -1 And arrayFeild(i, j - 1).m_Type = 0 Then
                        arrayFeild(i, j - 1).m_Dist = count + 1
                        counted = True
                    End If
                End If
            Next j
        Next i
        'So basically if there are still blocks left to count/mark/measure distance, keep going/check the next distance
        'If no blocks left, return the optimal amount of moves
        If counted = True Then
            Return Recursive_End(count + 1)
        Else
            Return count
        End If
    End Function
    Private Function Recursive_Maze(ByVal b As block)
        ''Basically this recursive function randomly picks a block in any direction and makes it a path (unless it already has an adjacent path)
        ''If there are no blocks left, it goes back to the previous block
        ''Rinse and repeat
        'Counter for debugging
        counter += 1
        'Checks to see if there is still stuff to backtrack to.
        If arrayBackTrack.Count >= 1 Then
            Dim arrayDirection As New ArrayList
            'Creates an array of directions, to see which have been checked
START:
            'Checks to see that there are still directions to check
            If arrayDirection.Count <= 3 Then
                Randomize()
                'I know theres a more efficeint way to do this, but i do not know how to actually do it
                'Randomly generates a direction, same as movement up(0), down(2) etc etc
                Dim direction As Integer = CInt(Rnd() * 3)
                'if there are already previously chekced directions check if the current direction has already been checked
                If arrayDirection.Count > 0 Then
                    For i = 0 To arrayDirection.Count - 1
                        If arrayDirection(i) = direction Then
                            direction = CInt(Rnd() * 3)
                            'regenerate direction (nice efficiency)
                            GoTo start
                        End If
                    Next
                End If
                Select Case direction
                    Case Is = 0
                        'Makes sure the current block is inside the bounds of the maze
                        If b.arrayLocation.Y > 1 Then
                            'Checks if the block 2 blocks to the whatever direction is a wall
                            If arrayFeild(b.arrayLocation.X, b.arrayLocation.Y - 2).m_Type = 1 Then
                                'if it is, then adds the current block to the backtrack
                                arrayBackTrack.Add(b)
                                'Makes the current block an empty space
                                arrayFeild(b.arrayLocation.X, b.arrayLocation.Y).type(0)
                                'Makes the block inbetween the to an empty space
                                arrayFeild(b.arrayLocation.X, b.arrayLocation.Y - 1).type(0)
                                'Makes the block that was checked an empty space
                                arrayFeild(b.arrayLocation.X, b.arrayLocation.Y - 2).type(0)
                                'Restarts the function with the new block (the one that was checked 2 spaces away)
                                Return Recursive_Maze(arrayFeild(b.arrayLocation.X, b.arrayLocation.Y - 2))
                            Else
                                'if not, add the direction to the list of checked directions and regenerate a direction
                                arrayDirection.Add(0)
                                GoTo start
                            End If
                        Else
                            'if the direction is out of bounds, add it to the list, and regenerate
                            arrayDirection.Add(0)
                            GoTo start
                        End If
                        'Same as above
                    Case Is = 1
                        If b.arrayLocation.X < arrayWidth - 3 Then
                            If arrayFeild(b.arrayLocation.X + 2, b.arrayLocation.Y).m_Type = 1 Then
                                arrayBackTrack.Add(b)
                                arrayFeild(b.arrayLocation.X + 1, b.arrayLocation.Y).type(0)
                                arrayFeild(b.arrayLocation.X + 2, b.arrayLocation.Y).type(0)
                                Return Recursive_Maze(arrayFeild(b.arrayLocation.X + 2, b.arrayLocation.Y))
                            Else
                                arrayDirection.Add(1)
                                GoTo start
                            End If
                        Else
                            arrayDirection.Add(1)
                            GoTo start
                        End If
                    Case Is = 2
                        If b.arrayLocation.Y < arrayHeight - 3 Then
                            If arrayFeild(b.arrayLocation.X, b.arrayLocation.Y + 2).m_Type = 1 Then
                                arrayBackTrack.Add(b)
                                arrayFeild(b.arrayLocation.X, b.arrayLocation.Y + 1).type(0)
                                arrayFeild(b.arrayLocation.X, b.arrayLocation.Y + 2).type(0)
                                Return Recursive_Maze(arrayFeild(b.arrayLocation.X, b.arrayLocation.Y + 2))
                            Else
                                arrayDirection.Add(2)
                                GoTo start
                            End If
                        Else
                            arrayDirection.Add(2)
                            GoTo start
                        End If
                    Case Is = 3
                        If b.arrayLocation.X > 1 Then
                            If arrayFeild(b.arrayLocation.X - 2, b.arrayLocation.Y).m_Type = 1 Then
                                arrayBackTrack.Add(b)
                                arrayFeild(b.arrayLocation.X - 1, b.arrayLocation.Y).type(0)
                                arrayFeild(b.arrayLocation.X - 2, b.arrayLocation.Y).type(0)
                                Return Recursive_Maze(arrayFeild(b.arrayLocation.X - 2, b.arrayLocation.Y))
                            Else
                                arrayDirection.Add(3)
                                GoTo start
                            End If
                        Else
                            arrayDirection.Add(3)
                            GoTo start

                        End If
                    Case Else
                        'just in case hahahahahahahahahahahahahahahahahaha
                        GoTo start
                End Select
            Else
                'if all 4 directions are occupied by spaces or out of bounds, the go back to the previous block in the backtrack stack and remove it from the stack
                Dim back As block = arrayBackTrack(arrayBackTrack.Count - 1)
                arrayBackTrack.RemoveAt((arrayBackTrack.Count - 1))
                Return Recursive_Maze(back)
            End If
        Else
            'if the maze is done generating return 1 (I DONT KNOW WHAT ELSE TO RETURN)
            Return 1
        End If
    End Function
End Class
