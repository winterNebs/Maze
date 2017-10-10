Public Class block
    'Is basically a picturebox with extra properties
    Inherits PictureBox
    'Those extra properties
    Public m_Type As Integer
    Private m_Location As Point
    Public m_Dist As Integer
    'Default constructer (never used i think)
    Public Sub New()
        m_Type = 0
        Me.Size = New Point(32, 32)
        Me.SizeMode() = PictureBoxSizeMode.StretchImage
        Me.Visible = True
        Me.Location = New Point(0, 0)
        type(m_Type)
        m_Dist = -1
    End Sub
    Public Sub New(ByVal type As Integer, ByVal size As Point, ByVal location As Point, ByVal arrayLocation As Point)
        'The actually useful constructer
        'Sets the type to whatever is instructed (only ever type 1 when using the constructer)
        m_Type = type
        'Sets its physical size to the one given 
        Me.Size = New Point(size.X - 1, size.Y - 1)
        'Making sure the picture box works nice and dandy
        Me.SizeMode() = PictureBoxSizeMode.StretchImage
        Me.Visible = True
        'Sets actual location to the location
        Me.Location = location
        'Sets the type to the type
        Me.type(m_Type)
        'Sets the location to where it is in the array
        m_Location = arrayLocation
        'Sets the distance from the player to -1 (BASICALLY MEANS THAT IT HASNT BEEN CHECKED)
        m_Dist = -1
    End Sub
    Public Sub type(ByVal blocktype As Integer)
        'Sets the readable property to whatever type the user wants
        m_Type = blocktype
        'Actually sets the image of the picturebox to whatever type
        Select Case blocktype
            Case Is = 0
                'Off/empty/no block/space/path
                'Basically where the player moves around 
                Me.Image = My.Resources.off
            Case Is = 1
                'Walls/black/occupied
                'Basically walls of the maze, player cant go through
                Me.Image = My.Resources._on
            Case Is = 2
                'Player/start(until they move)
                Me.Image = My.Resources.player
            Case Is = 3
                'End/finish/objective
                Me.Image = My.Resources._end
            Case Is = 4
                'Previously traveled blocks
                Me.Image = My.Resources.past
            Case Is = 5
            Case Is = 6
            Case Is = 7
        End Select
    End Sub
    Public Property arrayLocation
        'setting/getting array location zzzZzZzZZzzZZZZ...
        Get
            Return m_Location
        End Get
        Set(ByVal value)
            m_Location = value
        End Set
    End Property

End Class
