
import AddDoctorForm from "../AddDoctor/AddDoctorForm.tsx";
import StatisticsWidget from "../StaticticsWidget/StatisticsWidget.tsx";
import { Box, Grid, WrapItem } from "@chakra-ui/react"
import { Heading } from '@chakra-ui/react'
import { Avatar, AvatarBadge, AvatarGroup } from '@chakra-ui/react'
import ScheduleTable from "../ScheduleTable/ScheduleTable.tsx";

export default function Dashboard() {

    return (
        <div>
            <Heading>
                <WrapItem>
                <Avatar size='2xl' name='Kola Tioluwani' src="/whiteDent2.png"/>
            </WrapItem>
            </Heading>
            <StatisticsWidget/>
            <AddDoctorForm/>
            <ScheduleTable/>
        </div>
    )
}