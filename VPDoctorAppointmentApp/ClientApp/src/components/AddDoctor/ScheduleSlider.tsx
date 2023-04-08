
import {
    RangeSlider,
    RangeSliderTrack,
    RangeSliderFilledTrack,
    RangeSliderThumb, RangeSliderMark,
} from '@chakra-ui/react'
import {useState} from "react";


export default function ScheduleSlider(props) {
    const [sliderValue, setSliderValue] = useState([8, 16])
    
    return (
        <RangeSlider aria-label={['min', 'max']} defaultValue={[8, 16]} min={8} max = {22}

                     onChange={(val) => {setSliderValue(val);
                         props.onInputValueChange(val, props.index) }}
                     
                             
                     style={{display : 'inline-block'}}>

            <RangeSliderMark
                value={sliderValue[0]}
                textAlign='center'
                bg='blue.500'
                color='white'
                mt='-10'
                ml='-5'
                w='12'
            >
                {sliderValue[0]}
            </RangeSliderMark>
            <RangeSliderMark
                value={sliderValue[1]}
                textAlign='center'
                bg='blue.500'
                color='white'
                mt='-10'
                ml='-5'
                w='12'
            >
                {sliderValue[1]}
            </RangeSliderMark>
            
            <RangeSliderTrack>
                <RangeSliderFilledTrack />
            </RangeSliderTrack>
            <RangeSliderThumb index={0} />
            <RangeSliderThumb index={1} />
        </RangeSlider>
    )
}