import React from 'react';
import {BoldExtension} from 'remirror/extensions';
import {Remirror, useRemirror} from '@remirror/react';

const extensions = () => [new BoldExtension()];

export const ControlledEditor = () => {
    const {manager, state, setState} = useRemirror({
        extensions,

        // Add the string handler so that the initial
        // state can created from a html string.
        stringHandler: 'html',

        // This content is used to create the initial value. It is never referred to again after the first render.
        content: '<p>This is the initial value</p>',
    });

    // Add the state and create an `onChange` handler for the state.
    return (
        <Remirror
            autoRender={'start'}
            manager={manager}
            state={state}
            onChange={(parameter) => {
                // Update the state to the latest value.
                console.log("doc json is:", JSON.stringify(state.doc.toJSON(), null, 2))
                setState(parameter.state);
            }}
        />
    );
};

