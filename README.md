# TODO

[] Make sure to fix key press bug where a number is represented by Dn (D1, D2, etc)
[] Show corresponding note when key is pressed
[] Have black keys show a change by changing the sprite
[x] Place the work of generating the piano sound double and playing the note in Audio in a Task
    - You can use an anonymous Task for this
[x] Add a critical section to the Play method of the Audio class ensuring that only one Task at a time can access the buffer.
