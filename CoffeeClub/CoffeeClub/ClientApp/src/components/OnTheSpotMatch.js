import React, { useState } from 'react';

const OnTheSpotMatch = () => {
    const [personId, setPersonId] = useState(0);
    const [match, setMatch] = useState(null);

    const onTheSpotMatch = async () => {
        const response = await fetch('api/onthespotmatch', {
            method: 'POST',
            headers: {
                id: personId
            }
        });
        if (response.text == '') return;
        const data = await response.json();
        setMatch(data);
    }

    return (
        <div>
            <h1>On the spot match</h1>

            <form>
                <div class="form-group">
                    <label for="personId">Your Person ID</label>
                    <input type="number" class="form-control" id="personId" onChange={(e) => setPersonId(e.target.value)} value={personId} />
                </div>
            </form>
            <button className="btn btn-primary" onClick={onTheSpotMatch}>Match</button>
        </div>
    );
}

export default OnTheSpotMatch;