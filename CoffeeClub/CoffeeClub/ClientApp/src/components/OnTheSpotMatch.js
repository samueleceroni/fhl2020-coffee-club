import React, { useState } from 'react';

const OnTheSpotMatch = () => {
    const [personId, setPersonId] = useState(0);
    const [match, setMatch] = useState({ loading: false, match: null, addedToQueue: false });

    const onTheSpotMatch = async () => {
        setMatch({ loading: true })
        const response = await fetch('api/onthespotmatch', {
            method: 'POST',
            headers: {
                id: personId
            }
        });
        const text = await response.text();
        if (text == '') {
            setMatch({ loading: false, match: null, addedToQueue: true });
        }
        else {
            const data = JSON.parse(text);
            setMatch({ loading: false, match: data });
        }
    }

    let matchDetails = '';

    if (match.loading) {
        matchDetails = 'Loading...';
    }
    else if (match.match) {
        matchDetails = `You were matched to ${match.match.firstName} ${match.match.secondName}.`;
    }
    else if (match.addedToQueue) {
        matchDetails = 'We couldn\'t find a match for you at the moment, so we added you to the queue.';
    }

    return (
        <div>
            <h1>On the spot match</h1>

            <form>
                <div className="form-group">
                    <label htmlFor="personId">Your Person ID</label>
                    <input type="number" className="form-control" id="personId" onChange={(e) => setPersonId(e.target.value)} value={personId} />
                </div>
            </form>
            <button className="btn btn-primary" onClick={onTheSpotMatch}>Match</button>
            <p>{matchDetails}</p>
        </div>
    );
}

export default OnTheSpotMatch;